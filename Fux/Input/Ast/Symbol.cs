namespace Fux.Input.Ast
{
    public abstract class Symbol : Expr.ExprImpl
    {
        public Symbol(Token token)
        {
            Token = token;
        }

        public Token Token { get; }

        public override void PP(Writer writer)
        {
            writer.Write($"{Token}");
        }
    }
}
