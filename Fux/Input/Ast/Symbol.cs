namespace Fux.Input.Ast
{
    internal abstract class Symbol : Expression
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
