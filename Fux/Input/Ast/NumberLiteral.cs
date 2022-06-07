namespace Fux.Input.Ast
{
    internal class NumberLiteral : Literal
    {
        public NumberLiteral(Token token)
            : base(token)
        {
            Assert(token.Lex == Lex.Number);
        }
    }
}
