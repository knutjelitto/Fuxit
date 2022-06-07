namespace Fux.Input
{
    internal class Liner
    {
        private Token? current = null;

        private TokenList tokens = new();

        public Liner(ErrorBag errors, Lexer lexer)
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

            return ParseLine(0, tokens);
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

        private Token Consume(int indent)
        {
            var token = Current;

            token.Indent = indent;

            current = null;

            return token;
        }

        private Tokens ParseLine(int indent, Tokens tokens)
        {
            var starter = Current;

            Current.First = true;

            while (!Current.EOF && Current.Line == starter.Line)
            {
                tokens.Add(Consume(indent));
            }

            tokens.Last().Last = true;

            if (!Current.EOF && Current.Column > starter.Column)
            {
                indent = indent + 1;

                _ = ParseLine(indent, tokens);

                while (!Current.EOF && Current.Column > starter.Column)
                {
                    _ = ParseLine(indent, tokens);
                }
            }

            Assert(tokens.Count > 0);

            return tokens;
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
