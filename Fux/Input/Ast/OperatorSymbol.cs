namespace Fux.Input.Ast
{
    internal class OperatorSymbol : Symbol
    {
        public OperatorSymbol(Token token) : base(token)
        {
        }

        public string Text => Token.ToString();

        public override string ToString()
        {
            return $"({Token})";
        }

        public virtual Expression Combine(Expression lhs, Expression rhs)
        {
            return new InfixExpr(this, lhs, rhs);
        }
    }
}
