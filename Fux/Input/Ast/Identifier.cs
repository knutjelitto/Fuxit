namespace Fux.Input.Ast
{
    internal sealed class Identifier : ListOf<Token>
    {
        private string toString;
        private int hashCode;

        public Identifier(IEnumerable<Token> tokens)
            : base(tokens)
        {
            Assert(Count > 0);
            Assert(this.All(token => token.Lex == Lex.LowerId || token.Lex == Lex.UpperId || token.Lex == Lex.OperatorId));

            toString = $"{string.Join('.', this)}";
            hashCode = toString.GetHashCode();
        }

        public Identifier(params Token[] tokens)
            : this(tokens.AsEnumerable())
        {
        }

        public TypeHint? TypeHint { get; set; } = null;

        public bool IsSingle(Lex lex) => Count == 1 && this[0].Lex == lex;
        public bool IsMulti(Lex lex) => this.All(t => t.Lex == lex);

        public Identifier SingleLower()
        {
            Assert(IsSingle(Lex.LowerId));

            return this;
        }

        public Identifier SingleLowerOrOp()
        {
            Assert(IsSingle(Lex.LowerId) || IsSingle(Lex.OperatorId));

            return this;
        }

        public Identifier SingleOp()
        {
            Assert(IsSingle(Lex.OperatorId));

            return this;
        }

        public Identifier SingleUpper()
        {
            Assert(IsSingle(Lex.UpperId));

            return this;
        }

        public string MultiUpper()
        {
            Assert(IsMulti(Lex.UpperId));

            return toString;
        }

        public override bool Equals(object? obj) => obj is Identifier other && toString == other.toString;
        public override int GetHashCode() => hashCode;
        public override string ToString() => toString;

        public override void PP(Writer writer)
        {
            writer.Write(ToString());
        }
    }
}
