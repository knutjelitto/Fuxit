namespace Fux.Input.Ast
{
    internal class OpExpr
    {
        public OpExpr(OperatorSymbol op, Expr expression)
        {
            Op = op;
            Expression = expression;
        }

        public OperatorSymbol Op { get; }
        public Expr Expression { get; }

        public override string ToString()
        {
            return $"({Op} {Expression})";
        }
    }
}
