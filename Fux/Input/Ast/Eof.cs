namespace Fux.Input.Ast
{
    public sealed class Eof : Declaration.DeclImpl
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
