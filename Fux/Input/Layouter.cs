using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class Layouter
    {
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

        private IEnumerable<Token> Iterable()
        {
            var newlines = new List<Token>();
            var whites = new List<Token>();

            var lastToken = Lexer.Bof();

            while (true)
            {
                newlines.Clear();
                whites.Clear();

                var token = Lexer.Scan();

                if (token.Newline)
                {
                    if (!token.StartContinuation && !lastToken.EndContinuation)
                    {
                        yield return new Token(Lex.Semicolon, token);
                    }

                    do
                    {
                        newlines.Add(token);

                        token = Lexer.Scan();
                    }
                    while (token.Newline);
                }

                while (token.White)
                {
                    whites.Add(token);

                    token = Lexer.Scan();
                }

                token.AddSpaces(newlines.Concat(whites));

                yield return token;

                lastToken = token;

                if (token.Lex == Lex.EOF)
                {
                    break;
                }
            }
        }
    }
}
