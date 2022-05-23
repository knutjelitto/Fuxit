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
        private Whites? whitesBefore = new();

        public Token(Lex lex, ILocation location)
        {
            Lex = lex;
            Location = location;
        }

        public Token(Lex lex, Token template)
            : this(lex, template.Location)
        {
        }

        public Lex Lex { get; }
        public ILocation Location { get; }
        public int Column => Location.Column;
        public int Line => Location.Line;

        public bool White => Lex == Lex.Newline || Lex == Lex.Space || Lex == Lex.BlockComment || Lex == Lex.LineComment;
        public bool Newline => Lex == Lex.Newline;
        public Whites Whites => whitesBefore ?? new Whites();

        public bool Atomic =>
            Lex == Lex.Operator ||
            Lex == Lex.LowerId ||
            Lex == Lex.UpperId ||
            Lex == Lex.Number ||
            Lex == Lex.String;

        public bool StartContinuation =>
            Lex == Lex.Operator ||
            Lex == Lex.LParent ||
            Lex == Lex.RParent ||
            Lex == Lex.RBrace ||
            Lex == Lex.LBrace ||
            Lex == Lex.RBracket ||
            Lex == Lex.KwThen ||
            Lex == Lex.KwElse ||
            Lex == Lex.Comma;

        public bool EndContinuation =>
            Lex == Lex.Operator ||
            Lex == Lex.LParent ||
            Lex == Lex.LBrace ||
            Lex == Lex.LBracket ||
            Lex == Lex.KwThen ||
            Lex == Lex.KwElse ||
            Lex == Lex.Comma;

        public Token TransferWhites(Whites whites)
        {
            whitesBefore = whites;

            return this;
        }

        public string Text => Location.Text;

        public override string ToString()
        {
            return Text;
        }

        public string Dbg()
        {
            return $"{Lex}(\"{Location.Text}\",{Location})";
        }
    }
}
