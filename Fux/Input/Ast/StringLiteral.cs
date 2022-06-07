namespace Fux.Input.Ast
{
    internal class StringLiteral : Literal
    {
        public StringLiteral(Token token)
            : base(token)
        {
            Assert(token.Lex == Lex.String);
        }
    }
}
