namespace Fux.Input.Ast
{
    public sealed class OperatorSymbol : Symbol
    {
        public OperatorSymbol(Token token) : base(token)
        {
            Name = new Identifier(Token.Artifical(Lex.OperatorId, Token, $"({token.Text})"));
        }

        public Identifier Name { get; }

        public string Text => Token.ToString();

        public Decl.Infix? InfixDecl { get; set; }

        public override string ToString()
        {
            return $"({Token})";
        }

        public Expr Combine(Expr lhs, Expr rhs)
        {
            return new Expr.Infix(this, lhs, rhs);
        }
    }
}
