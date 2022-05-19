using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    [DebuggerDisplay("{Dbg()}")]
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

        public Token(Lex lex, Token template)
            : this(template.Lexer, lex, template.Start, template.End)
        {
        }

        public Lexer Lexer { get; }
        public Lex Lex { get; }
        public int Start { get; }
        public int End { get; }

        public bool White => Lex == Lex.Space;
        public bool Newline => Lex == Lex.Newline;

        public bool Atomic =>
            Lex == Lex.Operator ||
            Lex == Lex.LowerId ||
            Lex == Lex.UpperId ||
            Lex == Lex.Number ||
            Lex == Lex.String;

        public bool StartContinuation =>
            Lex == Lex.Operator ||
            Lex == Lex.RParent ||
            Lex == Lex.RBrace ||
            Lex == Lex.RBracket;

        public bool EndContinuation =>
            Lex == Lex.Operator ||
            Lex == Lex.LParent ||
            Lex == Lex.LBrace ||
            Lex == Lex.LBracket;

        public void AddSpaces(IEnumerable<Token> spaces)
        {
            spacesBefore.AddRange(spaces);
        }

        public override string ToString()
        {
            return new Runes(Lexer.Text.Skip(Start).Take(End - Start)).ToString();
        }

        public string Dbg()
        {
            var value = string.Empty;
            if (End > Start)
            {
                value = "(" + this + ")";
            }

            return $"{Lex}{value}";
        }
    }
}
