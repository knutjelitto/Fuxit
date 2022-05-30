using Fux.Input;

namespace Fux.Ast
{
    internal class Eof : Expression
    {
        public Eof(Token token)
        {
            Token = token;
        }

        public override bool IsAtomic => true;

        public Token Token { get; }

        public override void PP(Writer writer)
        {
            writer.WriteLine(Lex.EOF);
        }
    }
}
