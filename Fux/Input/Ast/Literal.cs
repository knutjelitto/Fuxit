namespace Fux.Input.Ast
{
    internal abstract class Literal : Expression
    {
        public Literal(Token token)
        {
            Token = token;
        }

        public Token Token { get; }

        public override string ToString()
        {
            return $"{Token}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Token}");
        }
    }
}
