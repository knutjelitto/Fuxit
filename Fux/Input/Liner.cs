namespace Fux.Input
{
    public sealed class Liner
    {
        private int current = 0;

        private TokenList tokens = new();

        public Liner(ErrorBag errors, Lexer lexer)
        {
            Errors = errors;
            Lexer = lexer;
            CreateTokenList();
        }

        public ErrorBag Errors { get; }
        public Lexer Lexer { get; }

        public Tokens GetLine()
        {
            if (current == tokens.Count - 1)
            {
                Assert(tokens[current].Lex == Lex.EOF);
                return new Tokens(tokens, current, current + 1);
            }

            return ParseLine(0);
        }

        private int Consume(int indent)
        {
            tokens[current++].Indent = indent;

            return current;
        }

        private Tokens ParseLine(int indent)
        {
            var starter = current;

            tokens[current].First = true;

            while (current < tokens.Count && !tokens[current].EOF && tokens[current].Line == tokens[starter].Line)
            {
                current = Consume(indent);
            }

            tokens[current - 1].Last = true;

            if (current < tokens.Count && !tokens[current].EOF && tokens[current].Column > tokens[starter].Column)
            {
                indent = indent + 1;

                _ = ParseLine(indent);

                while (current < tokens.Count && !tokens[current].EOF && tokens[current].Column > tokens[starter].Column)
                {
                    _ = ParseLine(indent);
                }
            }

            Assert(current > starter);

            return new Tokens(tokens, starter, current);
        }

        private void CreateTokenList()
        {
            var current = Lexer.GetNext();

            while (true)
            {
                var whites = new Whites();

                while (current.White)
                {
                    whites.Add(current);

                    current = Lexer.GetNext();
                }

                current.TransferWhites(whites);

                tokens.Add(current);

                Assert(current.Index == tokens.Count - 1);

                if (current.Lex == Lex.EOF)
                {
                    break;
                }
                current = Lexer.GetNext();                    
            }
        }
    }
}
