using System.Collections;

namespace Fux.Input
{
    internal class Tokens : IReadOnlyList<Token>
    {
        private readonly List<Token> tokens = new();

        public Tokens(List<Token> underlying)
        {
        }

        public Tokens Add(Token token)
        {
            tokens.Add(token);

            return this;
        }

        public Token this[int index] => tokens[index];
        public int Count => tokens.Count;
        public IEnumerator<Token> GetEnumerator() => tokens.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)tokens).GetEnumerator();

        public override string ToString()
        {
            return string.Join(" ", tokens);
        }
    }
}
