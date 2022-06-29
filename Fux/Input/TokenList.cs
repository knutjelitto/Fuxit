using System.Collections;

namespace Fux.Input
{
    public sealed class TokenList : IReadOnlyList<Token>
    {
        private readonly List<Token> items = new();

        public Token Add(Token token)
        {
            Assert(token.Index == -1);

            token.Index = items.Count;

            items.Add(token);

            return token;
        }

        public Token this[int index] => items[index];
        public int Count => items.Count;
        public IEnumerator<Token> GetEnumerator() => items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
