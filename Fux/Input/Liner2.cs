namespace Fux.Input
{
    internal class Liner2
    {
        private Token? current = null;

        private TokenList tokens = new();

        public Liner2(ErrorBag errors, Lexer lexer)
        {
            Errors = errors;
            Lexer = lexer;
            Error = new ParserErrors(errors);
        }

        public ErrorBag Errors { get; }
        public Lexer Lexer { get; }

        public ParserErrors Error { get; }

        public Tokens GetLine()
        {
            if (Current.EOF)
            {
                Assert(this.tokens.Last().Lex == Lex.EOF);
                return new Tokens().Add(Current);
            }

            var tokens = new Tokens();

            try
            {
                return ParseLine(tokens);
            }
            catch (DiagnosticException diagnostic)
            {
                Errors.Add(diagnostic);

                return new Tokens();
            }
        }

        private Token Current
        {
            get
            {
                if (current == null)
                {
                    current = CreateNextToken();
                }
                return current;
            }
        }

        private Token Consume()
        {
            var token = Current;

            current = null;

            return token;
        }

        private Tokens ParseLine(Tokens tokens)
        {
            var starter = Current;

            while (!Current.EOF && Current.Line == starter.Line)
            {
                var token = Consume();

                tokens.Add(token);
            }

            if (!Current.EOF && Current.Column > starter.Column)
            {
                ParseIndented(tokens);
            }

            return tokens;
        }

        private bool IsCombiner(Token token)
        {
            return false
                || token.Lex == Lex.Comma
                || token.Lex == Lex.Colon
                || token.Lex == Lex.Define
                || token.Lex == Lex.Operator
                ;
        }

        private bool IsFirstCombiner(Token token)
        {
            return false
                || IsCombiner(token)
                || token.Lex == Lex.RParent
                || token.Lex == Lex.RBrace
                || token.Lex == Lex.RBracket
                ;
        }

        private bool IsLastCombiner(Token token)
        {
            return false
                || IsCombiner(token)
                || token.Lex == Lex.LParent
                || token.Lex == Lex.LBrace
                || token.Lex == Lex.LBracket
                ;
        }

        private void ParseIndented(Tokens tokens)
        {
            var starter = Current;

            var last = IsLastCombiner(tokens.Last());
            var first = IsFirstCombiner(starter);
            var flat = true && (last || first);

            if (!flat)
            {
                tokens.Begin(starter);
            }

            while (!Current.EOF && Current.Column == starter.Column || IsLastCombiner(tokens.Last()) || IsFirstCombiner(Current))
            {
                _ = ParseLine(tokens);
            }

            if (!flat)
            {
                tokens.End();
            }
        }

        private Token CreateNextToken()
        {
            var whites = new Whites();
            var current = tokens.Add(Lexer.GetNext());

            while (!current.EOF && current.White)
            {
                whites.Add(current);

                current = tokens.Add(Lexer.GetNext());
            }

            return current.TransferWhites(whites);
        }
    }
}
