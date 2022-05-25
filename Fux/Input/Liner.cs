namespace Fux.Input
{
    internal class Liner
    {
        private Token? current = null;

        public Liner(ErrorBag errors, Lexer lexer)
        {
            Lexer = lexer;
            Error = new ParserErrors(errors);
        }

        public Lexer Lexer { get; }

        public ParserErrors Error { get; }

        public Line GetLine()
        {
            if (Current.Lex == Lex.EOF)
            {
                return new Line(Current);
            }

            return ParseLine();
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

        private Line ParseLine()
        {
            var starter = Current;

            var line = new Line();
            var tokens = new Tokens();

            while (!Current.EOF && Current.Line == starter.Line)
            {
                var token = Consume();

                line.AddToken(token);
                tokens.Add(token);
            }

            if (!Current.EOF && Current.Column > starter.Column)
            {
                ParseLines(line, tokens);
            }

            line.Compress();

            return line;
        }

        private void ParseLines(Line parent, Tokens tokens)
        {
            var starter = Current;

            while (!Current.EOF && Current.Column == starter.Column)
            {
                parent.AddIndent(ParseLine());
            }
        }

        private Token CreateNextToken()
        {
            var whites = new Whites();
            var current = Lexer.GetNext();

            while (!current.EOF && current.White)
            {
                whites.Add(current);

                current = Lexer.GetNext();
            }

            return current.TransferWhites(whites);
        }
    }
}
