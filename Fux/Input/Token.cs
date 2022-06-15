namespace Fux.Input
{
    [DebuggerDisplay("{Dbg()}")]
    internal class Token
    {
        private readonly string? artifical = null;

        private Whites? whitesBefore = null;

        public Token(Lex lex, ILocation location)
        {
            Lex = lex;
            Location = location;
        }

        public Token(Lex lex, Token template)
            : this(lex, template.Location)
        {
        }

        private Token(Lex lex, Token template, string artifical)
            : this(lex, template)
        {
            this.artifical = artifical;
        }

        private Token(Lex lex, ILocation location, string artifical)
            : this(lex, location)
        {
            this.artifical = artifical;
        }

        public static Token Artifical(Lex lex, Token template, string artifical)
        {
            return new Token(lex, template, artifical);
        }

        public static Token Artifical(Lex lex, ILocation location, string artifical)
        {
            return new Token(lex, location, artifical);
        }

        public Lex Lex { get; }
        public ILocation Location { get; }
        public int Column => Location.Column;
        public int Line => Location.Line;

        public bool WhitesBefore => whitesBefore != null && whitesBefore.Count > 0;

        public int Indent { get; set; } = 0;
        public bool First { get; set; } = false;
        public bool Last { get; set; } = false;
        public bool Both => First && Last;
        public int Index { get; set; } = -1;

        public bool White => Lex == Lex.Newline || Lex == Lex.Space || Lex == Lex.BlockComment || Lex == Lex.LineComment;
        public bool Newline => Lex == Lex.Newline;
        public bool EOF => Lex == Lex.EOF;
        public Whites Whites => whitesBefore ?? new Whites();

        public bool Atomic =>
            Lex == Lex.Operator ||
            Lex == Lex.LowerId ||
            Lex == Lex.UpperId ||
            Lex == Lex.Number ||
            Lex == Lex.Char ||
            Lex == Lex.String;

        public bool StartContinuation =>
            Lex == Lex.Operator ||
            Lex == Lex.LParent ||
            Lex == Lex.RParent ||
            Lex == Lex.RBrace ||
            Lex == Lex.LBrace ||
            Lex == Lex.RBracket ||
            Lex == Lex.HardKwThen ||
            Lex == Lex.HardKwElse ||
            Lex == Lex.Comma;

        public bool EndContinuation =>
            Lex == Lex.Operator ||
            Lex == Lex.LParent ||
            Lex == Lex.LBrace ||
            Lex == Lex.LBracket ||
            Lex == Lex.HardKwThen ||
            Lex == Lex.HardKwElse ||
            Lex == Lex.Comma;

        public Token TransferWhites(Whites whites)
        {
            whitesBefore = whites;

            return this;
        }

        public string Text => artifical ?? Location.Text;

        public override string ToString()
        {
            return Text;
        }

        public string Dbg()
        {
            return $"{Lex}(\"{this}\",{Location})";
        }
    }
}
