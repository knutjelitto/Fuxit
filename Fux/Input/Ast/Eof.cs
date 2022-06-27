namespace Fux.Input.Ast
{
    internal class Eof : Expr
    {
        public Eof(Token token)
        {
            Token = token;
        }

        public Token Token { get; }

        public override void PP(Writer writer)
        {
            writer.WriteLine(Lex.EOF);
        }
    }
}
