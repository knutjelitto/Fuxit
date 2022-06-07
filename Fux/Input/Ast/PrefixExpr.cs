namespace Fux.Input.Ast
{
    internal class PrefixExpr : Expression
    {
        public PrefixExpr(OperatorSymbol op, Expression rhs)
        {
            Op = op;
            Rhs = rhs;
        }

        public OperatorSymbol Op { get; }
        public Expression Rhs { get; }

        public override string ToString()
        {
            return $"{Op.Text} {Rhs}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{this}");
        }
    }
}
