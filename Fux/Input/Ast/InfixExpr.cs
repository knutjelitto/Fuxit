namespace Fux.Input.Ast
{
    internal class InfixExpr : Expr
    {
        public InfixExpr(OperatorSymbol op, Expr lhs, Expr rhs)
        {
            Op = op;
            Lhs = lhs;
            Rhs = rhs;
        }

        public OperatorSymbol Op { get; }
        public Expr Lhs { get; }
        public Expr Rhs { get; }

        public override string ToString()
        {
            return Protected($"{Lhs} {Op.Text} {Rhs}");
        }

        public override void PP(Writer writer)
        {
            Lhs.PP(writer);
            writer.Write($" {Op.Text} ");
            Rhs.PP(writer);
        }
    }
}
