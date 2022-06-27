namespace Fux.Input.Ast
{
    internal class PrefixExpr : Expr
    {
        public PrefixExpr(OperatorSymbol op, Expr rhs)
        {
            Op = op;
            Rhs = rhs;
        }

        public OperatorSymbol Op { get; }
        public Expr Rhs { get; }

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
