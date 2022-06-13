using System.Collections;

namespace Fux.Input
{
    internal class Tokens : IReadOnlyList<Token>
    {
        public Tokens(TokenList tokens, int start, int next)
        {
            Toks = tokens;
            Start = start;
            Next = next;
        }

        public Tokens Add()
        {
            Next += 1;

            return this;
        }

        public TokenList Toks { get; }
        public int Start { get; }
        public int Next { get; private set; }

        public Token this[int index] => Toks[Start + index];
        public int Count => Next - Start;
        public IEnumerator<Token> GetEnumerator()
        {
            for (var index = Start; index < Next; ++index)
            {
                yield return Toks[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            return string.Join(" ", this);
        }
    }
}
