namespace Fux.Input.Ast
{
    internal class OperatorSymbol : Symbol
    {
        public OperatorSymbol(Token token) : base(token)
        {
            Name = new Identifier(Token.Artifical(Lex.OperatorId, Token, $"({token.Text})"));
        }

        public Identifier Name { get; }

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
