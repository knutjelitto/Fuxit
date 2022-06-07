namespace Fux.Input.Ast
{
    internal class OpExpr
    {
        public OpExpr(OperatorSymbol op, Expression expression)
        {
            Op = op;
            Expression = expression;
        }

        public OperatorSymbol Op { get; }
        public Expression Expression { get; }

        public override string ToString()
        {
            return $"{Op} {Expression}";
        }
    }
}
