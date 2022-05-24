using System.Collections.Generic;

namespace Fux.Input
{
    internal class Layout
    {
        private Token? current = null;
        private List<Token> tokens = new();

        public Layout(Lexer lexer)
        {
            Lexer = lexer;
            Iterator = Iterable().GetEnumerator();
        }

        public Lexer Lexer { get; }
        public IEnumerator<Token> Iterator { get; }

        public Token GetNext()
        {
            if (Iterator.MoveNext())
            {
                return Iterator.Current;
            }
            return Lexer.Eof();
        }

        private Token NextToken()
        {
            var whites = new Whites();
            var current = Lexer.GetNext();

            while (current.White)
            {
                whites.Add(current);

                current = Lexer.GetNext();
            }

            return current.TransferWhites(whites);
        }

        private Token Current
        {
            get
            {
                if (current == null)
                {
                    current = NextToken();
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

        private IEnumerable<Token> Collect()
        {
            var starter = Current;

            while (Current.Line == starter.Line)
            {
                if (Current.Lex == Lex.EOF)
                {
                    yield break;
                }
                yield return Consume();
            }

            if (!Current.Whites.IsTransparent)
            {
                throw Lexer.Error.IllegalWhitespace(Current);
            }

            Assert(Current.Line > starter.Line);

            if (Current.Column > starter.Column) // indented
            {
                var list = Iterable().ToList();
                foreach (var token in list)
                {
                    yield return token;
                }
            }
        }

        private IEnumerable<Token> Iterable()
        {
            var column = Current.Column;

            while (Current.Lex != Lex.EOF && Current.Column == column)
            {
                yield return new Token(Lex.LayoutStart, new Location(Lexer.Source, Current.Location.Offset, 0));

                var list = Collect().ToList();
                foreach (var token in list)
                {
                    yield return token;
                }

                yield return new Token(Lex.LayoutEnd, new Location(Lexer.Source, Current.Location.Offset, 0));
            }
        }
    }
}
