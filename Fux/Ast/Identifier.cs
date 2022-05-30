using Fux.Input;

namespace Fux.Ast
{
    internal class Identifier : Symbol
    {
        public Identifier(Token token) : base(token)
        {
            Assert(token.Lex == Lex.LowerId || token.Lex == Lex.UpperId || token.Lex == Lex.OperatorId);
        }

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
