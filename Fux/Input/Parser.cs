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

        public A.ModuleAst Module()
        {
            var header = (A.ModuleDecl)Outer();

            var expressions = new List<A.Expression>();

            var current = Outer();

            while (current is A.Expression declaration)
            {
                expressions.Add(declaration);

                current = Outer();

                if (current is A.Eof)
                {
                    break;
                }
            }

            return new A.ModuleAst(header, expressions);
        }

        public A.Expression Outer()
        {
            var tokens = Lexer.GetLine();
            var cursor = new TokensCursor(Errors.Parser, tokens);

            return Outer(cursor);
        }

        public A.Expression Outer(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                A.Expression? outer = null;

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
                    outer = new A.Eof(cursor.Advance());
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

        private A.ModuleDecl ModuleHeader(TokensCursor cursor)
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

                var where = new List<A.VarDecl>();

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

                        where.Add(new A.VarDecl(name, new A.Parameters(), expression));
                    }
                    while (cursor.SwallowIf(Lex.Comma));

                    cursor.Swallow(Lex.RBrace);
                }

                A.Exposing? exposing = null;

                if (cursor.IsWeak(Lex.Weak.Exposing))
                {
                    exposing = Exposing(cursor);
                }

                return new A.ModuleDecl(path, effect, where, exposing);
            });
        }

        public A.ImportDecl Import(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.KwImport);

                var path = Identifier(cursor).MultiUpper();

                A.Identifier? alias = null;

                if (cursor.SwallowIf(Lex.KwAs))
                {
                    alias = Identifier(cursor).MultiUpper();
                }

                A.Exposing? exposing = null;

                if (cursor.IsWeak(Lex.Weak.Exposing))
                {
                    exposing = Exposing(cursor);
                }

                return new A.ImportDecl(path, alias, exposing);
            });
        }

        private A.Exposing Exposing(TokensCursor cursor)
        {
            return cursor.Scope<A.Exposing>(cursor =>
            {
                Assert(cursor.IsWeak(Lex.Weak.Exposing));
                cursor.Swallow(Lex.LowerId);

                if (cursor.IsWeak(Lex.Weak.ExposeAll))
                {
                    cursor.Swallow(Lex.OperatorId);

                    return new A.ExposingAll();
                }

                cursor.Swallow(Lex.LParent);

                var exposed = new List<A.Exposed>();

                do
                {
                    if (cursor.Is(Lex.LowerId))
                    {
                        var name = new A.Identifier(cursor.Swallow(Lex.LowerId));
                        exposed.Add(new A.ExposedVar(name));
                    }
                    else if (cursor.Is(Lex.UpperId))
                    {
                        var name = new A.Identifier(cursor.Swallow(Lex.UpperId));
                        var inclusive = false;
                        if (cursor.IsWeak(Lex.Weak.ExposeAll))
                        {
                            cursor.Swallow(Lex.OperatorId);
                            inclusive = true;
                        }
                        exposed.Add(new A.ExposedType(name, inclusive));
                    }
                    else if (cursor.Is(Lex.OperatorId))
                    {
                        var name = new A.Identifier(cursor.Swallow(Lex.OperatorId));
                        exposed.Add(new A.ExposedVar(name));
                    }
                    else
                    {
                        Assert(false);
                        throw Errors.Parser.Unexpected(cursor.Current);
                    }
                }
                while (cursor.SwallowIf(Lex.Comma));

                cursor.Swallow(Lex.RParent);

                return new A.ExposingSome(exposed);
            });
        }

        public A.InfixDecl TopInfixDecl(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.KwInfix);
                var assocTok = cursor.Swallow(Lex.LowerId);
                var assoc = A.InfixAssoc.From(assocTok.Text);
                if (assoc == null)
                {
                    throw Errors.Parser.IllegalInfixAssoc(assocTok);
                }
                var prioTok = cursor.Swallow(Lex.Integer);
                var power = new A.InfixPower(prioTok);
                var operatorTok = cursor.Swallow(Lex.OperatorId);
                var operatorSymbol = new A.Identifier(operatorTok);
                var defineTok = cursor.Swallow(Lex.Assign);
                var definition = new A.Identifier(cursor.Swallow(Lex.LowerId));

                return new A.InfixDecl(assoc, power, operatorSymbol, definition);
            });
        }

        public A.Expression TopType(TokensCursor cursor)
        {
            return cursor.Scope<A.Expression>(cursor =>
            {
                var kwType = cursor.Swallow(Lex.KwType);

                var alias = false;
                if (cursor.IsWeak("alias"))
                {
                    cursor.Swallow(Lex.LowerId);
                    alias = true;
                }

                Assert(cursor.Is(Lex.UpperId));

                var name = new A.Identifier(cursor.Swallow(Lex.UpperId));

                var parameterList = new List<A.Type.Parameter>();

                while (cursor.IsNot(Lex.Assign))
                {
                    Assert(cursor.Is(Lex.LowerId));

                    var parameter = new A.Type.Parameter(new A.Identifier(cursor.Swallow(Lex.LowerId)));

                    parameterList.Add(parameter);
                }

                var assign = cursor.Swallow(Lex.Assign);

                if (alias)
                {
                    var def = Type(cursor);

                    return new A.AliasDecl(name, new A.TypeParameters(parameterList), def);
                }

                var ctors = new List<A.Type.Constructor>();

                ctors.Add(Constructor(cursor));

                while (cursor.SwallowIf(Lex.Bar))
                {
                    ctors.Add(Constructor(cursor));
                }

                return new A.UnionDecl(name, new A.TypeParameters(parameterList), new A.Constructors(ctors));
            });
        }

        public A.Expression Declaration(TokensCursor cursor)
        {
            return cursor.Scope<A.Expression>(cursor =>
            {
                var left = (A.SequenceExpr)Sequence(cursor, true);

                if (cursor.Is(Lex.Assign))
                {
                    if (left[0] is A.Identifier name && name.IsSingleLower)
                    {
                        cursor.Swallow(Lex.Assign);

                        var parameters = new A.Parameters(left.Skip(1).Select(e => new A.Parameter(e)));

                        Assert(name.IsSingleLower);

                        var expression = Expression(cursor);

                        return new A.VarDecl(name, parameters, expression);
                    }
                    else
                    {
                        cursor.Swallow(Lex.Assign);

                        var expression = Expression(cursor);

                        return new A.LetAssign(left, expression);
                    }
                }
                else if (cursor.SwallowIf(Lex.Colon))
                {
                    Assert(left.Count == 1 && left[0] is A.Identifier);

                    var name = (A.Identifier)left[0];

                    Assert(name.IsSingleLower);

                    var type = Type(cursor);

                    return new A.TypeHint(name, type);
                }
                else
                {
                    Assert(false);
                    throw Errors.Parser.NotImplemented(cursor.Current);
                }
            });
        }

        private A.Type UnionInstantiation(TokensCursor cursor)
        {
            return cursor.Scope<A.Type>(cursor =>
            {
                Assert(cursor.Is(Lex.UpperId));

                var name = Identifier(cursor).MultiUpper();

                var arguments = new List<A.Type>();

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
                            return new A.Type.Primitive.Int();
                        case Lex.Primitive.Float:
                            return new A.Type.Primitive.Float();
                        case Lex.Primitive.Bool:
                            return new A.Type.Primitive.Bool();
                        case Lex.Primitive.String:
                            return new A.Type.Primitive.String();
                    }

                    return new A.Type.Concrete(name);
                }

                return new A.Type.Union(name, new A.TypeArguments(arguments));
            });
        }

        private A.Type.Constructor Constructor(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Assert(cursor.Is(Lex.UpperId));

                var name = Identifier(cursor).MultiUpper();

                var arguments = new List<A.Type>();

                do
                {
                    while (cursor.More() && !cursor.TerminatesSomething)
                    {
                        var argument = TypeArgument(cursor);

                        arguments.Add(argument);
                    }
                }
                while (cursor.More() && !cursor.TerminatesSomething);

                return new A.Type.Constructor(name, new A.TypeArguments(arguments));
            });
        }

        private A.Type TypeArgument(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                if (cursor.Is(Lex.LowerId))
                {
                    var name = Identifier(cursor).SingleLower();

                    return new A.Type.Parameter(name);
                }
                else if (cursor.Is(Lex.UpperId))
                {
                    var name = Identifier(cursor).MultiUpper();

                    return new A.Type.Concrete(name);
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

        private A.Identifier Identifier(TokensCursor cursor)
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

                return new A.Identifier(tokens);
            });
        }

        private A.Identifier SingleIdentifier(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Is(Lex.LowerId, Lex.UpperId, Lex.OperatorId);

                return new A.Identifier(cursor.Advance());
            });
        }

        private A.Identifier SingleLowerIdentifier(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Assert(cursor.Is(Lex.LowerId));

                return new A.Identifier(cursor.Advance()).SingleLower();
            });
        }

        private A.Type Type(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var type = BaseType(cursor);

                if (cursor.SwallowIf(Lex.Arrow))
                {
                    type = new A.Type.Function(type, Type(cursor));
                }

                return type;
            });
        }

        private A.Type BaseType(TokensCursor cursor)
        {
            return cursor.Scope<A.Type>(cursor =>
            {
                if (cursor.Is(Lex.LParent))
                {
                    cursor.Swallow(Lex.LParent);

                    var types = new List<A.Type>();

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
                        return new A.Type.Unit();
                    }
                    else if (types.Count == 1)
                    {
                        var type = types[0];
                        type.Protect = true;
                        return type;
                    }
                    else if (types.Count == 2)
                    {
                        return new A.Type.Tuple2(types[0], types[1]);
                    }
                    else if (types.Count == 3)
                    {
                        return new A.Type.Tuple3(types[0], types[1], types[2]);
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
                        return new A.Type.NumberClass(name);
                    }

                    if (name.ToString() == "appendable")
                    {
                        return new A.Type.AppendableClass(name);
                    }

                    if (name.ToString() == "comparable")
                    {
                        return new A.Type.ComparableClass(name);
                    }

                    return new A.Type.Parameter(name);
                }

                Assert(false);
                throw new NotImplementedException();
            });
        }

        private A.Expression TupleLiteral(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.LParent);

                var expressions = new List<A.Expression>();

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
                    return new A.Unit();
                }
                else if (expressions.Count == 1)
                {
                    var expression = expressions[0];
                    expression.Protect = true;
                    return expression;
                }
                else
                {
                    return new A.TupleExpr(expressions);
                }
            });
        }

        private A.Type RecordType(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var left = cursor.Swallow(Lex.LBrace);

                var fields = new List<A.FieldDefine>();

                A.Type? baseType = null;

                if (cursor.IsNot(Lex.RBrace))
                {
                    var state = cursor.State;

                    baseType = Type(cursor);

                    Assert(baseType is A.Type.Parameter);

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

                return new A.Type.Record(baseType, fields.Cast<A.FieldDefine>());

                A.FieldDefine Field(TokensCursor cursor)
                {
                    var name = Identifier(cursor);
                    cursor.Swallow(Lex.Colon);
                    var type = Type(cursor);

                    return new A.FieldDefine(name, type);
                }
            });
        }

        private A.Expression RecordLiteral(TokensCursor cursor)
        {
            return cursor.Scope<A.Expression>(cursor =>
            {
                var left = cursor.Swallow(Lex.LBrace);

                if (cursor.Is(Lex.RBrace))
                {
                    cursor.Swallow(Lex.RBrace);

                    return new A.RecordPattern(Enumerable.Empty<A.FieldPattern>());
                }

                var fields = new List<A.Field>();
                var state = cursor.State;
                A.Identifier? baseName = SingleLowerIdentifier(cursor);

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

                if (fields.All(f => f is A.FieldAssign))
                {
                    return new A.RecordExpr(baseName, fields.Cast<A.FieldAssign>());
                }
                else if (fields.All(f => f is A.FieldPattern))
                {
                    Assert(baseName == null);
                    return new A.RecordPattern(fields.Cast<A.FieldPattern>());
                }

                Assert(false);
                throw new NotImplementedException();

                A.Field Field(TokensCursor cursor)
                {
                    var name = SingleLowerIdentifier(cursor);

                    if (cursor.Is(Lex.Assign))
                    {
                        var assign = cursor.Swallow(Lex.Assign);
                        var value = Expression(cursor);

                        return new A.FieldAssign(name, value);
                    }
                    else
                    {
                        return new A.FieldPattern(name);
                    }
                }
            });
        }

        private A.ListExpr ListLiteral(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var left = cursor.Swallow(Lex.LBracket);

                var expressions = new List<A.Expression>();

                while (cursor.At().Lex != Lex.RBracket)
                {
                    expressions.Add(Expression(cursor));

                    if (cursor.IsNot(Lex.RBracket))
                    {
                        cursor.Swallow(Lex.Comma);
                    }
                }

                var right = cursor.Swallow(Lex.RBracket);

                return new A.ListExpr(left, right, expressions);
            });
        }

        private A.Expression InlineIf(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.KwIf);
                var condition = Expression(cursor);
                cursor.Swallow(Lex.KwThen);
                var whenTrue = Expression(cursor);
                cursor.Swallow(Lex.KwElse);
                var whenFalse = Expression(cursor);

                return new A.IfExpr(condition, whenTrue, whenFalse);
            });
        }

        private A.Expression InlineLet(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var kwLet = cursor.Swallow(Lex.KwLet);
                var lets = new List<A.Expression>();
                while (cursor.IsNot(Lex.KwIn))
                {
                    var subCursor = cursor.Sub();

                    var decl = Declaration(subCursor);

                    lets.Add(decl);
                }
                var kwIn = cursor.Swallow(Lex.KwIn);
                var expression = Expression(cursor);

                return new A.LetExpr(lets, expression);
            });
        }

        private A.Expression InlineCase(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.KwCase);
                var expression = Expression(cursor);
                cursor.Swallow(Lex.KwOf);

                var cases = new List<A.MatchCase>();

                while (cursor.StartsAtomic)
                {
                    var subCursor = cursor.Sub();

                    var pattern = Expression(subCursor);

                    subCursor.Swallow(Lex.Arrow);

                    var expr = Expression(subCursor);

                    var matchCase = new A.MatchCase(pattern, expr);

                    cases.Add(matchCase);
                }

                return new A.MatchExpr(expression, cases);
            });
        }

        private A.Expression Expression(TokensCursor cursor)
        {
            return OperatorExpr(cursor);
        }

        private A.Expression OperatorExpr(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var expr = PrefixExpr(cursor);
                if (cursor.Is(Lex.Operator))
                {
                    var opExprs = new List<A.OpExpr>();

                    while (cursor.Is(Lex.Operator))
                    {
                        var op = new A.OperatorSymbol(cursor.Swallow(Lex.Operator));

                        opExprs.Add(new A.OpExpr(op, PrefixExpr(cursor)));
                    }

                    return new A.OpChain(expr, opExprs);
                }

                return expr;
            });
        }


        private A.Expression PrefixExpr(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                A.Expression app;

                if (cursor.IsOperator())
                {
                    var op = new A.OperatorSymbol(cursor.Advance());
                    var argument = Sequence(cursor, false);

                    switch (op.Text)
                    {
                        case "-":
                            app = new A.SequenceExpr(Fake.NativeNegate(Source), argument);
                            break;
                        default:
                            Assert(false);
                            app = new A.PrefixExpr(op, argument);
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

        private A.Expression Sequence(TokensCursor cursor, bool always)
        {
            return cursor.Scope(cursor =>
            {
                var expressions = new List<A.Expression>();

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

                return new A.SequenceExpr(expressions);
            });
        }

        private A.Expression Compound(TokensCursor cursor)
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

        private A.Expression Atom(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Assert(cursor.StartsAtomic);

                A.Expression atom = ParseAtom(cursor);

                while (cursor.Is(Lex.Dot) && !cursor.WhitesBefore())
                {
                    cursor.Swallow(Lex.Dot);

                    atom = new A.SelectExpr(atom, ParseAtom(cursor));
                }

                return atom;

                A.Expression ParseAtom(TokensCursor cursor)
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
                    else if (cursor.Is(Lex.LongString))
                    {
                        return LongStringLiteral(cursor);
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

        private A.Expression Dot(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.Dot);
                var expr = SingleIdentifier(cursor);

                return new A.DotExpr(expr);
            });
        }

        private A.Expression Wildcard(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Wildcard);

                return new A.Wildcard(token);
            });
        }

        private A.Expression CharLiteral(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Char);

                return new A.CharLiteral(token);
            });
        }

        private A.Expression StringLiteral(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.String);

                return new A.StringLiteral(token);
            });
        }

        private A.Expression LongStringLiteral(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.LongString);

                return new A.LongStringLiteral(token);
            });
        }

        private A.Expression IntegerLiteral(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Integer);

                return new A.IntegerLiteral(token);
            });
        }

        private A.Expression FloatLiteral(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Float);

                return new A.FloatLiteral(token);
            });
        }

        private A.Expression Lambda(TokensCursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.Lambda);

                var parameters = (A.SequenceExpr)Sequence(cursor, true);

                cursor.Swallow(Lex.Arrow);

                var expr = Expression(cursor);

                return new A.LambdaExpr(parameters, expr);
            });
        }
    }
}
