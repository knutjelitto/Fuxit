namespace Fux.Input
{
    internal class Liner
    {
        private Token? current = null;

        public Liner(Lexer lexer)
        {
            Lexer = lexer;
            Error = new ParserErrors();
        }

        public Lexer Lexer { get; }

        public ParserErrors Error { get; }

        public Line GetLine()
        {
            if (Current.Lex == Lex.EOF)
            {
                return new Line(Current);
            }

            return CreateLine();
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

        private Line CreateLine()
        {
            var starter = Current;

            var line = new Line();

            while (!Current.EOF && Current.Line == starter.Line)
            {
                line.AddToken(Consume());
            }

            if (Current.Column > starter.Column)
            {
                CreateLines(line);
            }

            line.Compress();

            return line;
        }

        private void CreateLines(Line parent)
        {
            var starter = Current;

            while (!Current.EOF && Current.Column == starter.Column)
            {
                parent.AddIndent(CreateLine());
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
