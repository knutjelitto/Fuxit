using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class Layouter
    {
        private Token? current = null;

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

        private Token Current
        {
            get
            {
                if (current == null)
                {
                    current = Lexer.CreateNext();
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

        private IEnumerable<Token> Iterable(int indent, Whites whites)
        {
            if (Current.Lex == Lex.EOF)
            {
                yield break;
            }

            Assert(whites.IsValidBeforeIndent);
            Assert(Current.Indent == indent);

            var before = Current;

            while (true)
            {
                yield return Consume().TransferWhites(whites);

                whites = CollectWhite();

                if (whites.IsValidInline)
                {
                    continue;
                }

                if (whites.IsValidBeforeIndent)
                {
                    if (Current.Indent > indent)
                    {
                        yield return new Token(Lex.LayoutIndent, new Location(Current.Location.Source, before.Location.Next, 0));

                        foreach (var token in Iterable(Current.Indent, whites))
                        {
                            yield return token;
                        }

                        yield return new Token(Lex.LayoutUndent, new Location(Current.Location.Source, before.Location.Next, 0));
                    }
                    else if (Current.Indent == indent)
                    {
                        yield return new Token(Lex.LayoutSame, new Location(Current.Location.Source, before.Location.Next, 0));

                        continue;
                    }
                    else
                    {
                        yield break;
                    }
                }
            }
        }

        private IEnumerable<Token> Iterable()
        {
            var whites = CollectWhite();

            if (Current.Lex == Lex.EOF)
            {
                yield return Consume().TransferWhites(whites);

                yield break;
            }

            Assert(Current.Indent == 1);

            foreach (var token in Iterable(Current.Indent, whites))
            {
                yield return token;
            }
        }

        private Whites CollectWhite()
        {
            var whites = new Whites();
            while (Current.White)
            {
                whites.Add(Consume());
            }
            return whites;
        }
    }
}
