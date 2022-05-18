using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class Token
    {
        private readonly List<Token> spacesBefore = new List<Token>();

        public Token(Lexer lexer, Lex lex, int start, int end)
        {
            Lexer = lexer;
            Lex = lex;
            Start = start;
            End = end;
        }

        public Lexer Lexer { get; }
        public Lex Lex { get; }
        public int Start { get; }
        public int End { get; }

        public bool White => Lex == Lex.Space;
        public bool Newline => Lex == Lex.Newline;

        public void AddSpaces(IEnumerable<Token> spaces)
        {
            spacesBefore.AddRange(spaces);
        }

        public override string ToString()
        {
            var value = string.Empty;
            if (End > Start)
            {
                value = "(" + new Runes(Lexer.Text.Skip(Start).Take(End - Start)) + ")";
            }

            return $"{Lex}{value}";
        }
    }
}
