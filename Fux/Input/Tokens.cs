using System.Collections;

namespace Fux.Input
{
    public class Tokens : IReadOnlyList<Token>
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

        public Token this[int index] => Toks[Start + index];
        public int Count => Next - Start;

        public TokenList Toks { get; }
        public int Start { get; }
        public int Next { get; private set; }

        public bool Eof => Start == Toks.Count - 1;

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
