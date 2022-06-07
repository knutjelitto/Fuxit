namespace Fux.Input.Ast
{
    internal class SequenceExpr : ListOf<Expression>
    {
        public SequenceExpr(IEnumerable<Expression> expressions)
            : base(expressions)
        {
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
