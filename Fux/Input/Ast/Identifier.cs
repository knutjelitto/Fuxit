namespace Fux.Input.Ast
{
    internal class Identifier : ListOf<Token>
    {
        public Identifier(IEnumerable<Token> tokens)
            : base(tokens)
        {
            Assert(this.Count > 0);
            Assert(this.All(token => token.Lex == Lex.LowerId || token.Lex == Lex.UpperId || token.Lex == Lex.OperatorId));
        }

        public Identifier(params Token[] tokens)
            : this(tokens.AsEnumerable())
        {
        }

        public bool IsSingle(Lex lex) => this.Count == 1 && this[0].Lex == lex;
        public bool IsMulti(Lex lex) => this.All(t => t.Lex == lex);

        public string SingleLower()
        {
            Assert(IsSingle(Lex.LowerId));

            return this[0].Text;
        }

        public string SingleOp()
        {
            Assert(IsSingle(Lex.OperatorId));

            return this[0].Text;
        }

        public string SingleUpper()
        {
            Assert(IsSingle(Lex.UpperId));

            return this[0].Text;
        }


        public override string ToString()
        {
            return $"{string.Join('.', this)}";
        }

        public override void PP(Writer writer)
        {
            writer.Write(ToString());
        }
    }
}
