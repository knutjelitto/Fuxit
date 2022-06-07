namespace Fux.Input.Ast
{
    internal class CharLiteral : Literal
    {
        public CharLiteral(Token token)
            : base(token)
        {
            Assert(token.Lex == Lex.Char);
        }
    }
}
