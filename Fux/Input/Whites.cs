using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class Whites
    {
        private readonly List<Token> whites = new();
        private bool validBeforeLexeme = true;
        private bool validInline = true;

        public void Add(Token white)
        {
            Assert(white.White);

            if (white.Lex == Lex.BlockComment || white.Lex == Lex.LineComment)
            {
                validBeforeLexeme = false;
            }
            else if (white.Lex == Lex.Newline)
            {
                validBeforeLexeme = true;
                validInline = false;
            }
            else
            {
                validBeforeLexeme = validBeforeLexeme && white.Lex == Lex.Space;
            }

            whites.Add(white);
        }

        public bool IsValidBeforeIndent => validBeforeLexeme;
        public bool IsValidInline => validInline;

        public override string ToString()
        {
            return String.Join("", whites);
        }
    }
}
