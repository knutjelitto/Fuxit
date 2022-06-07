namespace Fux.Input.Ast
{
    internal class Wildcard : Symbol
    {
        public Wildcard(Token token) : base(token)
        {
        }

        public override string ToString()
        {
            return $"{Token}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Lex.Wildcard}");
        }
    }
}
