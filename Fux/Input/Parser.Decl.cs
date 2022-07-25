#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable IDE0028 // Simplify collection initialization
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CS0219 // Variable is assigned but its value is never used
#pragma warning disable IDE0066 // Convert switch statement to expression

using Fux.Building;

namespace Fux.Input
{
    public class DeclParser
    {
        public DeclParser(Parser parser)
        {
            Parser = parser;
        }

        public Parser Parser { get; }
        public Module Module => Parser.Module;
        public ErrorBag Errors => Parser.Errors;
        public ExprParser Expr => Parser.Expr;
        public TypeParser Type => Parser.Type;
        public PatternParser Patt => Parser.Patt;

        public A.Decl.Header ModuleHeader(Cursor cursor)
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

                var path = Parser.Identifier(cursor).MultiUpper();

                var where = new List<A.Decl.Var>();

                if (cursor.SwallowIf(Lex.KwWhere))
                {
                    //TODO: what's a where?
                    cursor.Swallow(Lex.LeftCurlyBracket);

                    do
                    {
                        var name = Parser.SingleIdentifier(cursor).SingleLower();
                        cursor.Swallow(Lex.Assign);
                        var expression = Expr.Expression(cursor);

                        where.Add(new A.Decl.Var(Module, name, new A.Parameters(), expression));
                    }
                    while (cursor.SwallowIf(Lex.Comma));

                    cursor.Swallow(Lex.RCurlyBracket);
                }

                A.Exposing? exposing = null;

                if (cursor.Is(Lex.KwExposing))
                {
                    exposing = Exposing(cursor);
                }

                return new A.Decl.Header(Module, path, effect, port, where, exposing);
            });
        }

        public A.Decl.Import ImportDecl(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.KwImport);

                var path = Parser.Identifier(cursor).MultiUpper();

                A.Identifier? alias = null;

                if (cursor.SwallowIf(Lex.KwAs))
                {
                    alias = Parser.Identifier(cursor).MultiUpper();
                }

                A.Exposing? exposing = null;

                if (cursor.Is(Lex.KwExposing))
                {
                    exposing = Exposing(cursor);
                }

                return new A.Decl.Import(Module, path, alias, exposing);
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

                cursor.Swallow(Lex.LeftRoundBracket);

                var exposed = new List<A.Exposed>();

                do
                {
                    if (cursor.Is(Lex.LowerId))
                    {
                        var name = Parser.SingleIdentifier(cursor).SingleLower();
                        exposed.Add(new A.Exposed.Var(name));
                    }
                    else if (cursor.Is(Lex.UpperId))
                    {
                        var name = Parser.SingleIdentifier(cursor).SingleUpper();
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
                        var name = Parser.SingleIdentifier(cursor).SingleOp();
                        exposed.Add(new A.Exposed.Var(name));
                    }
                    else
                    {
                        Assert(false);
                        throw Errors.Parser.Unexpected(cursor.Current);
                    }
                }
                while (cursor.SwallowIf(Lex.Comma));

                cursor.Swallow(Lex.RightRoundBracket);

                return new A.ExposingSome(exposed);
            });
        }

        public A.Decl.Infix InfixDecl(Cursor cursor)
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
                var operatorSymbol = Parser.SingleIdentifier(cursor).SingleOp();
                var defineTok = cursor.Swallow(Lex.Assign);
                var definition = Parser.Identifier(cursor).Qualified(); ;

                return new A.Decl.Infix(Module, assoc, power, operatorSymbol, definition);
            });
        }

        public A.NamedDecl CustomOrAliasDecl(Cursor cursor)
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

                var name = Parser.SingleIdentifier(cursor).SingleUpper();

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
                    var definition = Type.Type(cursor);

                    return new A.Decl.Alias(Module, name, new A.Decl.TypeParameterList(parameterList), definition);
                }

                var custom = new A.Decl.Custom(Module, name, new A.Decl.TypeParameterList(parameterList));
                var ctors = new A.CtorList();

                ctors.Add(Ctor(custom, cursor));

                while (cursor.SwallowIf(Lex.Bar))
                {
                    ctors.Add(Ctor(custom, cursor));
                }

                Assert(custom.Ctors.Count >= 1);

                return custom;
            });
        }

        public A.Decl.TypeParameter TypeParameter(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                return new A.Decl.TypeParameter(Module, Parser.SingleIdentifier(cursor).SingleLower());
            });
        }

        public A.Decl VarDeclOrTypeAnnotationInLet(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                if (cursor.StartsTypeAnnotation)
                {
                    return TypeAnnotation(cursor);
                }
                else
                {
                    return VarDecl(cursor, inLet: true);
                }
            });
        }

        public A.Decl VarDecl(Cursor cursor, bool inLet)
        {
            return cursor.Scope<A.Decl>(cursor =>
            {
                var pattern = Patt.Pattern(cursor);

                cursor.Swallow(Lex.Assign);

                var expression = Expr.Expression(cursor);

                if (pattern is A.Pattern.Signature sign)
                {
                    var name = sign.Name.SingleLower();
                    var prms = sign.Parameters;

                    var parameters = new A.Parameters(prms.Select(pattern => new A.Decl.Parameter(pattern)));

                    return new A.Decl.Var(Module, name, parameters, expression);
                }
                else if (pattern is A.Pattern.LowerId lower)
                {
                    var name = lower.Identifier.SingleLower();

                    if (inLet && true)
                    {
                        return new A.Decl.LetAssign(pattern, expression);
                    }
                    else
                    {
                        var parameters = new A.Parameters(Enumerable.Empty<A.Decl.Parameter>());

                        return new A.Decl.Var(Module, name, parameters, expression);
                    }
                }
                else
                {
                    return new A.Decl.LetAssign(pattern, expression);
                }
            });
        }

        public A.Decl.TypeAnnotation TypeAnnotation(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                var name = Parser.SingleIdentifier(cursor).SingleLowerOrOp();

                cursor.Swallow(Lex.Colon);

                var type = Type.Type(cursor);

                return new A.Decl.TypeAnnotation(Module, name, type);
            });
        }

        private A.Decl.Ctor Ctor(A.Decl.Custom custom, Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                Assert(cursor.Is(Lex.UpperId));

                var name = Parser.Identifier(cursor).SingleUpper();

                var arguments = new List<A.Type>();

                do
                {
                    while (cursor.More() && !cursor.TerminatesSomething)
                    {
                        var argument = Type.TypeArgument(cursor);

                        arguments.Add(argument);
                    }
                }
                while (cursor.More() && !cursor.TerminatesSomething);

                var ctor = new A.Decl.Ctor(custom, Module, name, arguments);

                custom.Ctors.Add(ctor);

                return ctor;
            });
        }

        public A.Decl.TypeClass TypeClass(Cursor cursor)
        {
            return cursor.Scope(cursor =>
            {
                cursor.Swallow(Lex.KwClass);

                var name = Parser.SingleIdentifier(cursor).SingleUpper();

                var parameterList = new List<A.Decl.TypeParameter>();

                while (cursor.IsNot(Lex.KwWhere, Lex.Colon))
                {
                    Assert(cursor.Is(Lex.LowerId));

                    var parameter = TypeParameter(cursor);

                    parameterList.Add(parameter);
                }

                var typeClass = new A.Decl.TypeClass(Module, name, new A.Decl.TypeParameterList(parameterList));

                if (cursor.SwallowIf(Lex.Colon))
                {
                    var super = Super(typeClass, cursor);

                    while (cursor.IsNot(Lex.KwWhere))
                    {
                        super = Super(typeClass, cursor);
                    }
                }

                if (cursor.SwallowIf(Lex.KwWhere))
                {
                    do
                    {
                        var x = TypeAnnotation(cursor.Subcursor());
                    }
                    while (cursor.IsNot(Lex.EOF));
                }

                return typeClass;
            });
        }

        public A.Decl.SuperClass Super(A.Decl.TypeClass typeClass, Cursor cursor)
        {
            Assert(cursor.Is(Lex.UpperId));

            var name = Parser.Identifier(cursor).SingleUpper();

            var arguments = new List<A.Type>();

            do
            {
                while (cursor.More() && !cursor.TerminatesSomething)
                {
                    var argument = Type.TypeArgument(cursor);

                    arguments.Add(argument);
                }
            }
            while (cursor.More() && !cursor.TerminatesSomething);

            var super = new A.Decl.SuperClass(typeClass, Module, name, arguments);

            typeClass.Supers.Add(super);

            return super;

        }
    }
}
