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
            Typ = new TypeParser(this);
        }

        public Module Module { get; }
        public ErrorBag Errors { get; }
        public ISource Source => Lexer.Source;
        public ILexer Lexer { get; }
        public PatternParser Pattern { get; }
        public ExprParser Expr { get; }
        public TypeParser Typ { get; }

        public A.ModuleAst ParseModule()
        {
            var header = (A.Decl.Header)Outer();

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
                    outer = ImportDecl(cursor);
                }
                else if (cursor.Is(Lex.KwInfix))
                {
                    outer = InfixDecl(cursor);
                }
                else if (cursor.Is(Lex.KwType))
                {
                    outer = CustomOrAliasDecl(cursor);
                }
                else if (cursor.Is(Lex.EOF))
                {
                    outer = new A.Eof(cursor.Advance());
                }
                else if (cursor.StartsTypeAnnotation)
                {
                    outer = TypeAnnotation(cursor);
                }
                else
                {
                    outer = VarDecl(cursor);
                }

                if (cursor.More())
                {
                    throw Errors.Parser.Internal(cursor.At(), $"can not continue at token '{cursor.At()}'");
                }

                return outer;
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
    }
}
