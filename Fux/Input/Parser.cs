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
            Expr = new ExprParser(this);
        }

        public Module Module { get; }
        public ErrorBag Errors { get; }
        public ISource Source => Lexer.Source;
        public ILexer Lexer { get; }
        public PatternParser Pattern { get; }
        public ExprParser Expr { get; }

        public A.ModuleAst ParseModule()
        {
            var header = (A.Decl.Module)Outer();

            var declarations = new List<A.Decl>();

            var current = Outer();

            while (current is A.Decl declaration)
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

        public A.Decl Outer()
        {
            var tokens = Lexer.GetLine();
            var cursor = new Cursor(Module, Errors.Parser, tokens);

            return Outer(cursor);
        }

        public A.Decl Outer(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                A.Decl? outer = null;

                if (cursor.Is(Lex.KwModule, Lex.KwEffect, Lex.KwPort))
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

        private A.Decl.Module ModuleHeader(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var effect = false;
                var port = false;
                if (cursor.SwallowIf(Lex.KwEffect))
                {
                    //TODO: what's an effect?
                    effect = true;
                }
                else if (cursor.SwallowIf(Lex.KwPort))
                {
                    //TODO: what's an port?
                    port = true;
                }
                cursor.Swallow(Lex.KwModule);

                var path = Identifier(cursor).MultiUpper();

                var where = new List<A.Decl.Var>();

                if (cursor.SwallowIf(Lex.KwWhere))
                {
                    //TODO: what's a where?
                    cursor.Swallow(Lex.LBrace);

                    do
                    {
                        var name = SingleIdentifier(cursor).SingleLower();
                        cursor.Swallow(Lex.Assign);
                        var expression = Expr.Expression(cursor);

                        where.Add(new A.Decl.Var(name, new A.Parameters(), expression));
                    }
                    while (cursor.SwallowIf(Lex.Comma));

                    cursor.Swallow(Lex.RBrace);
                }

                A.Exposing? exposing = null;

                if (cursor.Is(Lex.KwExposing))
                {
                    exposing = Exposing(cursor);
                }

                return new A.Decl.Module(path, effect, port, where, exposing);
            });
        }

        public A.Decl.Import Import(Cursor cursor)
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

                if (cursor.Is(Lex.KwExposing))
                {
                    exposing = Exposing(cursor);
                }

                return new A.Decl.Import(path, alias, exposing);
            });
        }

        private A.Exposing Exposing(Cursor cursor)
        {
            return cursor.Scope<A.Exposing>(cursor =>
            {
                cursor.Swallow(Lex.KwExposing);

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
                        var name = SingleIdentifier(cursor).SingleLower();
                        exposed.Add(new A.Exposed.Var(name));
                    }
                    else if (cursor.Is(Lex.UpperId))
                    {
                        var name = SingleIdentifier(cursor).SingleUpper();
                        var inclusive = false;
                        if (cursor.IsWeak(Lex.Weak.ExposeAll))
                        {
                            cursor.Swallow(Lex.OperatorId);
                            inclusive = true;
                        }
                        exposed.Add(new A.Exposed.Type(name, inclusive));
                    }
                    else if (cursor.Is(Lex.OperatorId))
                    {
                        var name = SingleIdentifier(cursor).SingleOp();
                        exposed.Add(new A.Exposed.Var(name));
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

        public A.Decl.Infix TopInfixDecl(Cursor cursor)
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
                var operatorSymbol = SingleIdentifier(cursor).SingleOp();
                var defineTok = cursor.Swallow(Lex.Assign);
                var definition = Identifier(cursor).SingleLower(); ;

                return new A.Decl.Infix(assoc, power, operatorSymbol, definition);
            });
        }

        public A.NamedDecl TopType(Cursor cursor)
        {
            return cursor.Scope<A.NamedDecl>(cursor =>
            {
                var kwType = cursor.Swallow(Lex.KwType);

                var alias = false;
                if (cursor.SwallowIf(Lex.KwAlias))
                {
                    alias = true;
                }

                Assert(cursor.Is(Lex.UpperId));

                var name = SingleIdentifier(cursor).SingleUpper();

                var parameterList = new List<A.Decl.TypeParameter>();

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

                    return new A.Decl.Alias(name, new A.Decl.TypeParameterList(parameterList), def);
                }

                var custom = new A.Decl.Custom(name, new A.Decl.TypeParameterList(parameterList));
                var ctors = new A.CtorList();

                ctors.Add(Constructor(custom, cursor));

                while (cursor.SwallowIf(Lex.Bar))
                {
                    ctors.Add(Constructor(custom, cursor));
                }

                Assert(custom.Ctors.Count >= 1);

                return custom;
            });
        }

        public A.Decl.TypeParameter TypeParameter(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                return new A.Decl.TypeParameter(SingleIdentifier(cursor).SingleLower());
            });
        }

        public A.Decl.TypeAnnotation TypeAnnotation(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var name = SingleLowerIdentifier(cursor);

                if (name.Text == "concat")
                {
                    Assert(true);
                }

                cursor.Swallow(Lex.Colon);

                var type = Type(cursor);

                return new A.Decl.TypeAnnotation(name, type);
            });
        }

        public A.Decl DeclarationOrTypeAnnotation(Cursor cursor)
        {
            return cursor.Scope<A.Decl>(cursor =>
            {
                if (cursor.StartsTypeAnnotation)
                {
                    return TypeAnnotation(cursor);
                }
                else
                {
                    var pattern = Pattern.Pattern(cursor);

                    cursor.SwallowIf(Lex.Assign);

                    var expression = Expr.Expression(cursor);

                    if (pattern is A.Pattern.Signature sign)
                    {
                        var name = sign.Name.SingleLower();
                        var prms = sign.Parameters;

                        var parameters = new A.Parameters(prms.Select(pattern => new A.Decl.Parameter(pattern)));

                        return new A.Decl.Var(name, parameters, expression);
                    }
                    else
                    {
                        return new A.Decl.LetAssign(pattern, expression);
                    }
                }
            });
        }

        private A.Decl.Ctor Constructor(A.Decl.Custom custom, Cursor cursor)
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

                var ctor = new A.Decl.Ctor(custom, name, new A.TypeArgumentList(arguments));

                custom.Ctors.Add(ctor);

                return ctor;
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

        public A.Identifier SingleIdentifier(Cursor cursor)
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
    }
}
