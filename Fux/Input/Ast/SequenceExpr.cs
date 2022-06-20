namespace Fux.Input.Ast
{
    internal class SequenceExpr : ListOf<Expression>
    {
        public SequenceExpr(IEnumerable<Expression> expressions)
            : base(expressions)
        {
            Assert(Count >= 1);
        }

        public bool IsApplication => Count >= 2;
        public bool IsSingle => Count == 1;

        public Expression Single
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
