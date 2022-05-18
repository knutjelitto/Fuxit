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
            Iterator = Nexter().GetEnumerator();
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

        public IEnumerable<Token> Nexter()
        {
            var newlines = new List<Token>();
            var whites = new List<Token>();

            var lastToken = Lexer.Bof();

            while (true)
            {
                newlines.Clear();
                whites.Clear();

                var token = Lexer.Scan();

                while (token.Newline)
                {
                    newlines.Add(token);

                    token = Lexer.Scan();
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
