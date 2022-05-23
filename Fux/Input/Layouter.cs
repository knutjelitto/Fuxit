using System.Collections.Generic;

namespace Fux.Input
{
    internal class Layouter
    {
        private Token? current = null;
        private List<Token> tokens = new();

        public Layouter(Lexer lexer)
        {
            Lexer = lexer;
            Iterator = Iterable().GetEnumerator();
        }

        public Lexer Lexer { get; }
        public IEnumerator<Token> Iterator { get; }

        public Token Next()
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
            var current = Lexer.CreateNext();

            while (current.White)
            {
                whites.Add(current);

                current = Lexer.CreateNext();
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
                foreach (var token in Collect().ToList())
                {
                    yield return token;
                }
            }
        }

        private IEnumerable<Token> Iterable()
{
            yield return new Token(Lex.LayoutStart, new Location(Lexer.Source, Current.Location.Offset, 0));

            foreach (var token in Collect().ToList())
            {
                yield return token;
            }

            yield return new Token(Lex.LayoutEnd, new Location(Lexer.Source, Current.Location.Offset, 0));
        }
    }
}
