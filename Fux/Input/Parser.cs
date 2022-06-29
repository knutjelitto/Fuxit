#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE0028 // Simplify collection initialization
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS0219 // Variable is assigned but its value is never used
#pragma warning disable IDE0066 // Convert switch statement to expression

using Fux.Building;

namespace Fux.Input
{
    public partial class Parser
    {
        public Parser(Module module, ErrorBag errors, ILexer lexer)
        {
            Module = module;
            Errors = errors;
            Lexer = lexer;
            Pattern = new PatternParser(this);
        }

        public Module Module { get; }
        public ErrorBag Errors { get; }
        public ILexer Lexer { get; }
        public ISource Source => Lexer.Source;
        public PatternParser Pattern { get; }

        public A.ModuleAst ParseModule()
        {
            var header = (A.ModuleDecl)Outer();

            var declarations = new List<A.Declaration>();

            var current = Outer();

            while (current is A.Declaration declaration)
            {
                declarations.Add(declaration);

                current = Outer();

                if (current is A.Eof)
                {
                    break;
                }
            }

            var ast = new A.ModuleAst(header, declarations);

            Module.Ast = ast;

            return ast;
        }

        public A.Declaration Outer()
        {
            var tokens = Lexer.GetLine();
            var cursor = new Cursor(Module, Errors.Parser, tokens);

            return Outer(cursor);
        }

        public A.Declaration Outer(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                A.Declaration? outer = null;

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
                    outer = DeclarationOrTypeAnnotation(cursor);
                }

                if (cursor.More())
                {
                    throw Errors.Parser.Internal(cursor.At(), $"can not continue at token '{cursor.At()}'");
                }

                return outer;
            });
        }

        private A.ModuleDecl ModuleHeader(Cursor cursor)
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

        public A.ImportDecl Import(Cursor cursor)
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

        private A.Exposing Exposing(Cursor cursor)
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

        public A.InfixDecl TopInfixDecl(Cursor cursor)
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
#if true
                var definition = Identifier(cursor).SingleLower(); ;
#else
                var definition = new A.Identifier(cursor.Swallow(Lex.LowerId));
#endif

                return new A.InfixDecl(assoc, power, operatorSymbol, definition);
            });
        }

        public A.NamedDeclaration TopType(Cursor cursor)
        {
            return cursor.Scope<A.NamedDeclaration>(cursor =>
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

                var parameterList = new List<A.TypeParameter>();

                while (cursor.IsNot(Lex.Assign))
                {
                    Assert(cursor.Is(Lex.LowerId));

                    var parameter = TypeParameter(cursor);

                    parameterList.Add(parameter);
                }

                cursor.Swallow(Lex.Assign);

                if (alias)
                {
                    var def = Type(cursor);

                    return new A.AliasDecl(name, new A.TypeParameterList(parameterList), def);
                }

                var ctors = new List<A.Constructor>();

                ctors.Add(Constructor(cursor));

                while (cursor.SwallowIf(Lex.Bar))
                {
                    ctors.Add(Constructor(cursor));
                }

                return new A.TypeDecl(name, new A.TypeParameterList(parameterList), new A.ConstructorList(ctors));
            });
        }

        public A.TypeParameter TypeParameter(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                return new A.TypeParameter(new A.Identifier(cursor.Swallow(Lex.LowerId)));
            });
        }

        public A.TypeAnnotation TypeAnnotation(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var name = SingleLowerIdentifier(cursor);

                cursor.Swallow(Lex.Colon);

                var type = Type(cursor);

                return new A.TypeAnnotation(name, type);
            });
        }

        public A.Declaration DeclarationOrTypeAnnotation(Cursor cursor)
        {
            return cursor.Scope<A.Declaration>(cursor =>
            {
                if (cursor.StartsTypeAnnotation)
                {
                    return TypeAnnotation(cursor);
                }
                else
                {
                    var pattern = Pattern.Pattern(cursor);

                    cursor.SwallowIf(Lex.Assign);

                    var expression = Expression(cursor);

                    if (pattern is A.Pattern.Signature sign)
                    {
                        var name = sign.Name.SingleLower();
                        var prms = sign.Parameters;

                        var parameters = new A.Parameters(prms.Select(pattern => new A.ParameterDecl(pattern)));

                        return new A.VarDecl(name, parameters, expression);
                    }
                    else
                    {
                        return new A.LetAssign(pattern, expression);
                    }
                }
            });
        }


        private A.Type TypeArgument(Cursor cursor)
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

        private A.Type Construction(Cursor cursor)
        {
            return cursor.Scope<A.Type>(cursor =>
            {
                var name = Identifier(cursor).MultiUpper();

                var arguments = new A.TypeArgumentList();

                do
                {
                    while (cursor.More() && !cursor.TerminatesSomething)
                    {
                        arguments.Add(TypeArgument(cursor));
                    }
                }
                while (cursor.More() && !cursor.TerminatesSomething);

#if false
                if (arguments.Count == 0)
                {
                    switch (name.Text)
                    {
                        case Lex.Primitive.Int:
                            return new A.Type.Primitive.Int(name);
                        case Lex.Primitive.Float:
                            return new A.Type.Primitive.Float(name);
                        case Lex.Primitive.Bool:
                            return new A.Type.Primitive.Bool(name);
                        case Lex.Primitive.String:
                            return new A.Type.Primitive.String(name);
                        case Lex.Primitive.Char:
                            return new A.Type.Primitive.Char(name);
                    }

                    return new A.Type.Concrete(name);
                }
                else if (arguments.Count == 1)
                {
                    if (name.Text == "List")
                    {
                        Assert(true);
                    }
                }
#endif
                return new A.Type.Union(name, arguments);
            });
        }

        private A.Constructor Constructor(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Assert(cursor.Is(Lex.UpperId));

                var name = Identifier(cursor).SingleUpper();

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

                return new A.Constructor(name, new A.TypeArgumentList(arguments));
            });
        }

        public A.Identifier Identifier(Cursor cursor)
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

        private A.Identifier SingleIdentifier(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Assert(cursor.Is(Lex.LowerId, Lex.UpperId, Lex.OperatorId));

                return new A.Identifier(cursor.Advance());
            });
        }

        public A.Identifier SingleLowerIdentifier(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Assert(cursor.Is(Lex.LowerId));

                return new A.Identifier(cursor.Advance()).SingleLower();
            });
        }

        private A.Type Type(Cursor cursor)
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

        private A.Type BaseType(Cursor cursor)
        {
            return cursor.Scope(cursor =>
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
                        return types[0];
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
                    return Construction(cursor);
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

        private A.Expr TupleLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.LParent);

                var expressions = new List<A.Expr>();

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
                    return new A.Expr.Unit();
                }
                else if (expressions.Count == 1)
                {
                    return expressions[0];
                }
                else
                {
                    return new A.Expr.Tuple(expressions);
                }
            });
        }

        private A.Type RecordType(Cursor cursor)
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

                A.FieldDefine Field(Cursor cursor)
                {
                    var name = Identifier(cursor);
                    cursor.Swallow(Lex.Colon);
                    var type = Type(cursor);

                    return new A.FieldDefine(name, type);
                }
            });
        }

        private A.Expr RecordLiteral(Cursor cursor)
        {
            return cursor.Scope<A.Expr>(cursor =>
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
                    return new A.Expr.Record(baseName, fields.Cast<A.FieldAssign>());
                }
                else if (fields.All(f => f is A.FieldPattern))
                {
                    Assert(baseName == null);
                    Assert(fields.Count >= 1);
                    return new A.RecordPattern(fields.Cast<A.FieldPattern>());
                }

                Assert(false);
                throw new NotImplementedException();

                A.Field Field(Cursor cursor)
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

        private A.Expr.List ListLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.LBracket);

                var expressions = new List<A.Expr>();

                while (cursor.At().Lex != Lex.RBracket)
                {
                    expressions.Add(Expression(cursor));

                    if (cursor.IsNot(Lex.RBracket))
                    {
                        cursor.Swallow(Lex.Comma);
                    }
                }

                cursor.Swallow(Lex.RBracket);

                return new A.Expr.List(expressions);
            });
        }

        private A.Expr InlineIf(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.KwIf);
                var condition = Expression(cursor);
                cursor.Swallow(Lex.KwThen);
                var whenTrue = Expression(cursor);
                cursor.Swallow(Lex.KwElse);
                var whenFalse = Expression(cursor);

                return new A.Expr.If(condition, whenTrue, whenFalse);
            });
        }

        private A.Expr InlineLet(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var kwLet = cursor.Swallow(Lex.KwLet);

                var lets = new List<A.Declaration>();
                while (cursor.IsNot(Lex.KwIn))
                {
                    var decl = DeclarationOrTypeAnnotation(cursor.Subcursor());

                    lets.Add(decl);
                }

                var kwIn = cursor.Swallow(Lex.KwIn);
                var expression = Expression(cursor);

                return new A.Expr.Let(lets, expression);
            });
        }

        private A.Expr InlineCase(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.KwCase);
                var expression = Expression(cursor);
                cursor.Swallow(Lex.KwOf);

                var cases = new List<A.MatchCase>();

                while (cursor.StartsAtomic)
                {
                    var subCursor = cursor.Subcursor();

                    var pattern = Pattern.Pattern(subCursor);

                    subCursor.Swallow(Lex.Arrow);

                    var expr = Expression(subCursor);

                    var matchCase = new A.MatchCase(pattern, expr)
                    {
                        Module = Module
                    };

                    cases.Add(matchCase);
                }

                return new A.Expr.Match(expression, cases);
            });
        }

        private A.Expr Expression(Cursor cursor)
        {
            return InfixExpr(cursor);
        }

        private A.Expr InfixExpr(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var expr = Sequence(cursor, false);
                
                if (cursor.StartsInfix)
                {
                    var opExprs = new List<A.OpExpr>();

                    while (cursor.Is(Lex.Operator))
                    {
                        var op = new A.OperatorSymbol(cursor.Swallow(Lex.Operator));

                        opExprs.Add(new A.OpExpr(op, Sequence(cursor, false)));
                    }

                    return new A.OpChain(expr, opExprs);
                }

                return expr;
            });
        }

        private A.Expr Sequence(Cursor cursor, bool always)
        {
            return cursor.Scope(cursor =>
            {
                var expressions = new List<A.Expr>();

                do
                {
                    if (cursor.Current.Line == 74)
                    {
                        Assert(true);
                    }
                    var expression = PrefixExpr(cursor);

                    expressions.Add(expression);
                }
                while (cursor.StartsAtomic || cursor.StartsPrefix);

                Assert(expressions.Count >= 1);

                if (!always && expressions.Count == 1)
                {
                    return expressions[0];
                }

                return new A.Expr.Sequence(expressions);
            });
        }


        private A.Expr PrefixExpr(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                if (cursor.Line == 72 && cursor.Column == 28)
                {
                    Assert(true);
                }

                A.Expr app;

                if (cursor.StartsPrefix)
                {
                    var op = new A.OperatorSymbol(cursor.Advance());
                    var argument = Compound(cursor);

                    switch (op.Text)
                    {
                        case "-":
                            app = new A.Expr.Sequence(Fake.NativeNegate(Module, Source), argument);
                            break;
                        default:
                            Assert(false);
                            app = new A.Expr.Prefix(op, argument);
                            break;
                    }
                }
                else
                {
                    app = Compound(cursor);
                }

                return app;
            });
        }

        private A.Expr Compound(Cursor cursor)
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

        private A.Expr Atom(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Assert(cursor.StartsAtomic);

                A.Expr atom = ParseAtom(cursor);

                while (cursor.Is(Lex.Dot) && !cursor.WhitesBefore())
                {
                    atom = SelectExpr(cursor, atom);
                }

                return atom;

                A.Expr.Select SelectExpr(Cursor cursor, A.Expr atom)
                {
                    return cursor.Scope(cursor =>
                    {
                        cursor.Swallow(Lex.Dot);

                        return new A.Expr.Select(atom, ParseAtom(cursor));
                    });
                }

                A.Expr ParseAtom(Cursor cursor)
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

        private A.Expr Dot(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.Dot);
                var expr = SingleIdentifier(cursor);

                return new A.Expr.Dot(expr);
            });
        }

        private A.Expr Wildcard(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Wildcard);

                return new A.Wildcard(token);
            });
        }

        public A.Expr.Literal.Char CharLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Char);

                return new A.Expr.Literal.Char(token);
            });
        }

        public A.Expr.Literal.String StringLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.String);

                return new A.Expr.Literal.String(token);
            });
        }

        public A.Expr.Literal.LongString LongStringLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.LongString);

                return new A.Expr.Literal.LongString(token);
            });
        }

        public A.Expr.Literal.Integer IntegerLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Integer);

                return new A.Expr.Literal.Integer(token);
            });
        }

        public A.Expr.Literal.Float FloatLiteral(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var token = cursor.Swallow(Lex.Float);

                return new A.Expr.Literal.Float(token);
            });
        }

        private A.Expr Lambda(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.Lambda);

                var pattern = Pattern.Lambda(cursor);

                cursor.Swallow(Lex.Arrow);

                var expr = Expression(cursor);

                return new A.Expr.Lambda(pattern, expr);
            });
        }
    }
}
