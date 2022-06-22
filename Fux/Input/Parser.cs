using A = Fux.Input.Ast;

#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE0028 // Simplify collection initialization
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS0219 // Variable is assigned but its value is never used
#pragma warning disable IDE0066 // Convert switch statement to expression

namespace Fux.Input
{
    internal class Parser
    {
        public Parser(ErrorBag errors, ILexer lexer)
        {
            Errors = errors;
            Lexer = lexer;
        }

        public ErrorBag Errors { get; }
        public ILexer Lexer { get; }
        public ISource Source => Lexer.Source;

        public ModuleAst Module()
        {
            var header = (ModuleDecl)Outer();

            var expressions = new List<Expression>();

            var current = Outer();

            while (current is Expression declaration)
            {
                expressions.Add(declaration);

                current = Outer();

                if (current is Eof)
                {
                    break;
                }
            }

            return new ModuleAst(header, expressions);
        }

        public Expression Outer()
        {
            var tokens = Lexer.GetLine();
            var cursor = new TokensCursor(Errors.Parser, tokens);

            return Outer(cursor);
        }

        public Expression Outer(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Expression? outer = null;

                if (cursor.Is(Lex.KwModule) || cursor.IsWeak(Lex.Weak.Effect) || cursor.IsWeak(Lex.Weak.Port))
                {
                    outer = ModuleHeader(cursor);
                }
                else if (cursor.Is(Lex.KwImport))
                {
                    outer = Import(cursor);
                }
                else if (cursor.Is(Lex.KwInfix))
                {
                    outer = TopInfixDecl(cursor);
                }
                else if (cursor.Is(Lex.KwType))
                {
                    outer = TopType(cursor);
                }
                else if (cursor.Is(Lex.EOF))
                {
                    outer = new Eof(cursor.Advance());
                }
                else
                {
                    outer = Declaration(cursor);
                }

                if (cursor.More())
                {
                    throw Errors.Parser.Internal(cursor.At(), $"can not continue at token '{cursor.At()}'");
                }

                return outer;
            });
        }

        private ModuleDecl ModuleHeader(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var effect = false;
                if (cursor.IsWeak(Lex.Weak.Effect))
                {
                    //TODO: what's an effect?
                    cursor.Advance();
                    effect = true;
                }
                else if (cursor.IsWeak(Lex.Weak.Port))
                {
                    Assert(false);
                    throw new NotImplementedException();
                }
                cursor.Swallow(Lex.KwModule);

                var path = Identifier(cursor).MultiUpper();

                var where = new List<VarDecl>();

                if (cursor.IsWeak(Lex.Weak.Where))
                {
                    //TODO: what's a where?

                    cursor.Advance();

                    cursor.Swallow(Lex.LBrace);

                    do
                    {
                        var name = SingleIdentifier(cursor).SingleLower();
                        cursor.Swallow(Lex.Assign);
                        var expression = Expression(cursor);

                        where.Add(new VarDecl(name, new Parameters(), expression));
                    }
                    while (cursor.SwallowIf(Lex.Comma));

                    cursor.Swallow(Lex.RBrace);
                }

                Exposing? exposing = null;

                if (cursor.IsWeak(Lex.Weak.Exposing))
                {
                    exposing = Exposing(cursor);
                }

                return new ModuleDecl(path, effect, where, exposing);
            });
        }

        public ImportDecl Import(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.KwImport);

                var path = Identifier(cursor).MultiUpper();

                Identifier? alias = null;

                if (cursor.SwallowIf(Lex.KwAs))
                {
                    alias = Identifier(cursor).MultiUpper();
                }

                Exposing? exposing = null;

                if (cursor.IsWeak(Lex.Weak.Exposing))
                {
                    exposing = Exposing(cursor);
                }

                return new ImportDecl(path, alias, exposing);
            });
        }

        private Exposing Exposing(TokensCursor cursor)
        {
            return cursor.Scope<Exposing>(cursor =>
            {
                Assert(cursor.IsWeak(Lex.Weak.Exposing));
                cursor.Swallow(Lex.LowerId);

                if (cursor.IsWeak(Lex.Weak.ExposeAll))
                {
                    cursor.Swallow(Lex.OperatorId);

                    return new ExposingAll();
                }

                cursor.Swallow(Lex.LParent);

                var exposed = new List<Exposed>();

                do
                {
                    if (cursor.Is(Lex.LowerId))
                    {
                        var name = new Identifier(cursor.Swallow(Lex.LowerId));
                        exposed.Add(new ExposedVar(name));
                    }
                    else if (cursor.Is(Lex.UpperId))
                    {
                        var name = new Identifier(cursor.Swallow(Lex.UpperId));
                        var inclusive = false;
                        if (cursor.IsWeak(Lex.Weak.ExposeAll))
                        {
                            cursor.Swallow(Lex.OperatorId);
                            inclusive = true;
                        }
                        exposed.Add(new ExposedType(name, inclusive));
                    }
                    else if (cursor.Is(Lex.OperatorId))
                    {
                        var name = new Identifier(cursor.Swallow(Lex.OperatorId));
                        exposed.Add(new ExposedVar(name));
                    }
                    else
                    {
                        Assert(false);
                        throw Errors.Parser.Unexpected(cursor.Current);
                    }
                }
                while (cursor.SwallowIf(Lex.Comma));

                cursor.Swallow(Lex.RParent);

                return new ExposingSome(exposed);
            });
        }

        public InfixDecl TopInfixDecl(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.KwInfix);
                var assocTok = cursor.Swallow(Lex.LowerId);
                var assoc = InfixAssoc.From(assocTok.Text);
                if (assoc == null)
                {
                    throw Errors.Parser.IllegalInfixAssoc(assocTok);
                }
                var prioTok = cursor.Swallow(Lex.Integer);
                var power = new InfixPower(prioTok);
                var operatorTok = cursor.Swallow(Lex.OperatorId);
                var operatorSymbol = new Identifier(operatorTok);
                var defineTok = cursor.Swallow(Lex.Assign);
                var definition = new Identifier(cursor.Swallow(Lex.LowerId));

                return new InfixDecl(assoc, power, operatorSymbol, definition);
            });
        }

        public Expression TopType(TokensCursor cursor)
        {
            return cursor.Scope<Expression>(cursor =>
            {
                var kwType = cursor.Swallow(Lex.KwType);

                var alias = false;
                if (cursor.IsWeak("alias"))
                {
                    cursor.Swallow(Lex.LowerId);
                    alias = true;
                }

                Assert(cursor.Is(Lex.UpperId));

                var name = new Identifier(cursor.Swallow(Lex.UpperId));

                var parameterList = new List<Type.Parameter>();

                while (cursor.IsNot(Lex.Assign))
                {
                    Assert(cursor.Is(Lex.LowerId));

                    var parameter = new Type.Parameter(new Identifier(cursor.Swallow(Lex.LowerId)));

                    parameterList.Add(parameter);
                }

                var assign = cursor.Swallow(Lex.Assign);

                if (alias)
                {
                    var def = Type(cursor);

                    return new AliasDecl(name, new TypeParameters(parameterList), def);
                }

                var ctors = new List<Type.Constructor>();

                ctors.Add(Constructor(cursor));

                while (cursor.SwallowIf(Lex.Bar))
                {
                    ctors.Add(Constructor(cursor));
                }

                return new UnionDecl(name, new TypeParameters(parameterList), new Constructors(ctors));
            });
        }

        public Expression Declaration(TokensCursor cursor)
        {
            return cursor.Scope<Expression>(cursor =>
            {
                var left = (SequenceExpr)Sequence(cursor, true);

                if (cursor.Is(Lex.Assign))
                {
                    if (left[0] is Identifier name && name.IsSingleLower)
                    {
                        cursor.Swallow(Lex.Assign);

                        var parameters = new Parameters(left.Skip(1).Select(e => new Parameter(e)));

                        Assert(name.IsSingleLower);

                        var expression = Expression(cursor);

                        return new VarDecl(name, parameters, expression);
                    }
                    else
                    {
                        cursor.Swallow(Lex.Assign);

                        var expression = Expression(cursor);

                        return new LetAssign(left, expression);
                    }
                }
                else if (cursor.SwallowIf(Lex.Colon))
                {
                    Assert(left.Count == 1 && left[0] is Identifier);

                    var name = (Identifier)left[0];

                    Assert(name.IsSingleLower);

                    var type = Type(cursor);

                    return new TypeHint(name, type);
                }
                else
                {
                    Assert(false);
                    throw Errors.Parser.NotImplemented(cursor.Current);
                }
            });
        }

        private Type UnionInstantiation(TokensCursor cursor)
        {
            return cursor.Scope<Type>(cursor =>
            {
                Assert(cursor.Is(Lex.UpperId));

                var name = Identifier(cursor).MultiUpper();

                var arguments = new List<Type>();

                do
                {
                    while (cursor.More() && !cursor.TerminatesSomething)
                    {
                        var argument = TypeArgument(cursor);

                        arguments.Add(argument);
                    }
                }
                while (cursor.More() && !cursor.TerminatesSomething);

                if (arguments.Count == 0)
                {
                    switch (name.Text)
                    {
                        case Lex.Primitive.Int:
                            return new Type.Primitive.Int();
                        case Lex.Primitive.Float:
                            return new Type.Primitive.Float();
                        case Lex.Primitive.Bool:
                            return new Type.Primitive.Bool();
                        case Lex.Primitive.String:
                            return new Type.Primitive.String();
                    }

                    return new Type.Concrete(name);
                }

                return new Type.Union(name, new TypeArguments(arguments));
            });
        }

        private Type.Constructor Constructor(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Assert(cursor.Is(Lex.UpperId));

                var name = Identifier(cursor).MultiUpper();

                var arguments = new List<Type>();

                do
                {
                    while (cursor.More() && !cursor.TerminatesSomething)
                    {
                        var argument = TypeArgument(cursor);

                        arguments.Add(argument);
                    }
                }
                while (cursor.More() && !cursor.TerminatesSomething);

                return new Type.Constructor(name, new TypeArguments(arguments));
            });
        }

        private Type TypeArgument(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                if (cursor.Is(Lex.LowerId))
                {
                    var name = Identifier(cursor).SingleLower();

                    return new Type.Parameter(name);
                }
                else if (cursor.Is(Lex.UpperId))
                {
                    var name = Identifier(cursor).MultiUpper();

                    return new Type.Concrete(name);
                }
                else if (cursor.Is(Lex.LParent))
                {
                    return Type(cursor);
                }
                else if (cursor.Is(Lex.LBrace))
                {
                    return Type(cursor);
                }

                Assert(false);
                throw new NotImplementedException();
            });
        }

        private Identifier Identifier(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var tokens = new List<Token>();

                do
                {
                    if (cursor.IsIdentifier())
                    {
                        var token = cursor.Advance();

                        tokens.Add(token);

                        if (token.Lex == Lex.LowerId || token.Lex == Lex.OperatorId)
                        {
                            break;
                        }
                    }
                    else
                    {
                        throw Errors.Parser.Unexpected(cursor.Current);
                    }
                }
                while (cursor.SwallowIf(Lex.Dot));

                return new Identifier(tokens);
            });
        }

        private Identifier SingleIdentifier(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Is(Lex.LowerId, Lex.UpperId, Lex.OperatorId);

                return new Identifier(cursor.Advance());
            });
        }

        private Identifier SingleLowerIdentifier(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Assert(cursor.Is(Lex.LowerId));

                return new Identifier(cursor.Advance()).SingleLower();
            });
        }

        private Type Type(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var type = BaseType(cursor);

                if (cursor.SwallowIf(Lex.Arrow))
                {
                    type = new Type.Function(type, Type(cursor));
                }

                return type;
            });
        }

        private Type BaseType(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                if (cursor.Is(Lex.LParent))
                {
                    cursor.Swallow(Lex.LParent);

                    var types = new List<Type>();

                    if (cursor.IsNot(Lex.RParent))
                    {
                        do
                        {
                            var type = Type(cursor);

                            types.Add(type);
                        }
                        while (cursor.SwallowIf(Lex.Comma));
                    }

                    cursor.Swallow(Lex.RParent);

                    if (types.Count == 0)
                    {
                        return new Type.Unit();
                    }
                    else if (types.Count == 1)
                    {
                        var type = types[0];
                        type.Protect = true;
                        return type;
                    }
                    else if (types.Count == 2)
                    {
                        return new Type.Tuple2(types[0], types[1]);
                    }
                    else if (types.Count == 3)
                    {
                        return new Type.Tuple3(types[0], types[1], types[2]);
                    }

                    Assert(false);
                    throw new NotImplementedException();
                }
                else if (cursor.Is(Lex.LBrace))
                {
                    return RecordType(cursor);
                }
                else if (cursor.Is(Lex.UpperId))
                {
                    return UnionInstantiation(cursor);
                }
                else if (cursor.Is(Lex.LowerId))
                {
                    var name = Identifier(cursor).SingleLower();

                    if (name.ToString() == "number")
                    {
                        return new Type.NumberClass(name);
                    }

                    if (name.ToString() == "appendable")
                    {
                        return new Type.AppendableClass(name);
                    }

                    if (name.ToString() == "comparable")
                    {
                        return new Type.ComparableClass(name);
                    }

                    return new Type.Parameter(name);
                }

                Assert(false);
                throw new NotImplementedException();
            });
        }

        private Expression TupleLiteral(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.LParent);

                var expressions = new List<Expression>();

                while (cursor.IsNot(Lex.RParent))
                {
                    expressions.Add(Expression(cursor));

                    if (cursor.Is(Lex.Comma))
                    {
                        cursor.Advance();

                        continue;
                    }
                }

                cursor.Swallow(Lex.RParent);

                if (expressions.Count == 0)
                {
                    return new Unit();
                }
                else if (expressions.Count == 1)
                {
                    var expression = expressions[0];
                    expression.Protect = true;
                    return expression;
                }
                else
                {
                    return new TupleExpr(expressions);
                }
            });
        }

        private Type RecordType(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var left = cursor.Swallow(Lex.LBrace);

                var fields = new List<FieldDefine>();

                Type? baseType = null;

                if (cursor.IsNot(Lex.RBrace))
                {
                    var state = cursor.State;

                    baseType = Type(cursor);

                    Assert(baseType is Type.Parameter);

                    if (cursor.IsNot(Lex.Bar))
                    {
                        baseType = null;
                        cursor.Reset(state);
                    }
                    else
                    {
                        cursor.Swallow(Lex.Bar);
                    }

                    do
                    {
                        fields.Add(Field(cursor));
                    }
                    while (cursor.SwallowIf(Lex.Comma));
                }

                cursor.Swallow(Lex.RBrace);

                return new Type.Record(baseType, fields.Cast<FieldDefine>());

                FieldDefine Field(TokensCursor cursor)
                {
                    var name = Identifier(cursor);
                    cursor.Swallow(Lex.Colon);
                    var type = Type(cursor);

                    return new FieldDefine(name, type);
                }
            });
        }

        private Expression RecordLiteral(TokensCursor cursor)
        {
            return cursor.Scope<Expression>(cursor =>
            {
                var left = cursor.Swallow(Lex.LBrace);

                if (cursor.Is(Lex.RBrace))
                {
                    cursor.Swallow(Lex.RBrace);

                    return new RecordPattern(Enumerable.Empty<FieldPattern>());
                }

                var fields = new List<Field>();
                var state = cursor.State;
                Identifier? baseName = SingleLowerIdentifier(cursor);

                if (cursor.IsNot(Lex.Bar))
                {
                    baseName = null;
                    cursor.Reset(state);
                }
                else
                {
                    var bar = cursor.Swallow(Lex.Bar);
                }

                do
                {
                    fields.Add(Field(cursor));
                }
                while (cursor.SwallowIf(Lex.Comma));

                cursor.Swallow(Lex.RBrace);

                if (fields.All(f => f is FieldAssign))
                {
                    return new RecordExpr(baseName, fields.Cast<FieldAssign>());
                }
                else if (fields.All(f => f is FieldPattern))
                {
                    Assert(baseName == null);
                    return new RecordPattern(fields.Cast<FieldPattern>());
                }

                Assert(false);
                throw new NotImplementedException();

                Field Field(TokensCursor cursor)
                {
                    var name = SingleLowerIdentifier(cursor);

                    if (cursor.Is(Lex.Assign))
                    {
                        var assign = cursor.Swallow(Lex.Assign);
                        var value = Expression(cursor);

                        return new FieldAssign(name, value);
                    }
                    else
                    {
                        return new FieldPattern(name);
                    }
                }
            });
        }

        private ListExpr ListLiteral(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var left = cursor.Swallow(Lex.LBracket);

                var expressions = new List<Expression>();

                while (cursor.At().Lex != Lex.RBracket)
                {
                    expressions.Add(Expression(cursor));

                    if (cursor.IsNot(Lex.RBracket))
                    {
                        cursor.Swallow(Lex.Comma);
                    }
                }

                var right = cursor.Swallow(Lex.RBracket);

                return new ListExpr(left, right, expressions);
            });
        }

        private Expression InlineIf(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.KwIf);
                var condition = Expression(cursor);
                cursor.Swallow(Lex.KwThen);
                var whenTrue = Expression(cursor);
                cursor.Swallow(Lex.KwElse);
                var whenFalse = Expression(cursor);

                return new IfExpr(condition, whenTrue, whenFalse);
            });
        }

        private Expression InlineLet(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var kwLet = cursor.Swallow(Lex.KwLet);
                var lets = new List<Expression>();
                while (cursor.IsNot(Lex.KwIn))
                {
                    var subCursor = cursor.Sub();

                    var decl = Declaration(subCursor);

                    lets.Add(decl);
                }
                var kwIn = cursor.Swallow(Lex.KwIn);
                var expression = Expression(cursor);

                return new LetExpr(lets, expression);
            });
        }

        private Expression InlineCase(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.KwCase);
                var expression = Expression(cursor);
                cursor.Swallow(Lex.KwOf);

                var cases = new List<MatchCase>();

                while (cursor.StartsAtomic)
                {
                    var subCursor = cursor.Sub();

                    var pattern = Expression(subCursor);

                    subCursor.Swallow(Lex.Arrow);

                    var expr = Expression(subCursor);

                    var matchCase = new MatchCase(pattern, expr);

                    cases.Add(matchCase);
                }

                return new MatchExpr(expression, cases);
            });
        }

        private Expression Expression(TokensCursor cursor)
        {
            return OperatorExpr(cursor);
        }

        private Expression OperatorExpr(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var expr = PrefixExpr(cursor);
                if (cursor.Is(Lex.Operator))
                {
                    var opExprs = new List<OpExpr>();

                    while (cursor.Is(Lex.Operator))
                    {
                        var op = new OperatorSymbol(cursor.Swallow(Lex.Operator));

                        opExprs.Add(new OpExpr(op, PrefixExpr(cursor)));
                    }

                    return new OpChain(expr, opExprs);
                }

                return expr;
            });
        }


        private Expression PrefixExpr(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Expression app;

                if (cursor.IsOperator())
                {
                    var op = new OperatorSymbol(cursor.Advance());
                    var argument = Sequence(cursor, false);

                    switch (op.Text)
                    {
                        case "-":
                            app = new SequenceExpr(Fake.NativeNegate(Source), argument);
                            break;
                        default:
                            Assert(false);
                            app = new PrefixExpr(op, argument);
                            break;
                    }
                }
                else
                {
                    app = Sequence(cursor, false);
                }

                return app;
            });
        }

        private Expression Sequence(TokensCursor cursor, bool always)
        {
            return cursor.Scope(cursor =>
            {
                var expressions = new List<Expression>();

                do
                {
                    var expression = Compound(cursor);

                    expressions.Add(expression);
                }
                while (cursor.StartsAtomic);

                Assert(expressions.Count >= 1);

                if (!always && expressions.Count == 1)
                {
                    return expressions[0];
                }

                return new SequenceExpr(expressions);
            });
        }

        private Expression Compound(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                if (cursor.Is(Lex.KwIf))
                {
                    return InlineIf(cursor);
                }
                else if (cursor.Is(Lex.KwLet))
                {
                    return InlineLet(cursor);
                }
                else if (cursor.Is(Lex.KwCase))
                {
                    return InlineCase(cursor);
                }
                else
                {
                    Assert(cursor.StartsAtomic);

                    var atom = Atom(cursor);

                    if (cursor.SwallowIf(Lex.KwAs))
                    {
                        var alias = Identifier(cursor).SingleLower();

                        atom.Alias = alias;
                    }

                    return atom;
                }
            });
        }

        private Expression Atom(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Assert(cursor.StartsAtomic);

                Expression atom = ParseAtom(cursor);

                while (cursor.Is(Lex.Dot) && !cursor.WhitesBefore())
                {
                    cursor.Swallow(Lex.Dot);

                    atom = new SelectExpr(atom, ParseAtom(cursor));
                }

                return atom;

                Expression ParseAtom(TokensCursor cursor)
                {
                    if (cursor.Is(Lex.LowerId))
                    {
                        return SingleIdentifier(cursor);
                    }
                    else if (cursor.Is(Lex.OperatorId))
                    {
                        return SingleIdentifier(cursor);
                    }
                    else if (cursor.Is(Lex.UpperId))
                    {
                        return Identifier(cursor);
                    }
                    else if (cursor.Is(Lex.Wildcard))
                    {
                        return Wildcard(cursor);
                    }
                    else if (cursor.Is(Lex.Integer))
                    {
                        return IntegerLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.Float))
                    {
                        return FloatLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.String))
                    {
                        return StringLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.Char))
                    {
                        return CharLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.LParent))
                    {
                        return TupleLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.LBrace))
                    {
                        return RecordLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.LBracket))
                    {
                        return ListLiteral(cursor);
                    }
                    else if (cursor.Is(Lex.Lambda))
                    {
                        return Lambda(cursor);
                    }
                    else if (cursor.Is(Lex.Dot))
                    {
                        return Dot(cursor);
                    }

                    throw Errors.Parser.NotImplemented(cursor.At());
                }
            });
        }

        private Expression Dot(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.Dot);
                var expr = SingleIdentifier(cursor);

                return new DotExpr(expr);
            });
        }

        private Expression Wildcard(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Wildcard);

                return new Wildcard(token);
            });
        }

        private Expression CharLiteral(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Char);

                return new CharLiteral(token);
            });
        }

        private Expression StringLiteral(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.String);

                return new StringLiteral(token);
            });
        }

        private Expression IntegerLiteral(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Integer);

                return new IntegerLiteral(token);
            });
        }

        private Expression FloatLiteral(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Float);

                return new FloatLiteral(token);
            });
        }

        private Expression Lambda(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.Lambda);

                var parameters = (SequenceExpr)Sequence(cursor, true);

                cursor.Swallow(Lex.Arrow);

                var expr = Expression(cursor);

                return new LambdaExpr(parameters, expr);
            });
        }
    }
}
