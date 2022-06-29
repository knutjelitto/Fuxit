namespace Fux.Input.Ast
{
    public sealed class SequenceExpr : ListOf<Expr>
    {
        public SequenceExpr(IEnumerable<Expr> expressions)
            : base(expressions)
        {
            Assert(Count >= 1);
        }

        public SequenceExpr(params Expr[] expressions)
            : this(expressions.AsEnumerable())
        {
        }

        public bool IsApplication => Count >= 2;
        public bool IsSingle => Count == 1;

        public Expr Single
        {
            get
            {
                Assert(IsSingle);
                return this[0];
            }
        }

        public override string ToString()
        {
            var joined = string.Join(" ", this);

            return Protected($"{joined}");
        }

        public override void PP(Writer writer)
        {
            writer.Write(ToString());
        }
    }
}
