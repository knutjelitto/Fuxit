namespace Fux.Input.Ast
{
    internal class InfixExpr : Expression
    {
        public InfixExpr(OperatorSymbol op, Expression lhs, Expression rhs)
        {
            Op = op;
            Lhs = lhs;
            Rhs = rhs;
        }

        public OperatorSymbol Op { get; }
        public Expression Lhs { get; }
        public Expression Rhs { get; }

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
