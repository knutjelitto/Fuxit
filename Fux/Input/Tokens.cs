using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class Tokens : IReadOnlyList<Token>
    {
        private readonly List<Token> tokens = new();

        public void Add(Token token)
        {
            tokens.Add(token);
        }

        public Token this[int index] => tokens[index];
        public int Count => tokens.Count;
        public IEnumerator<Token> GetEnumerator() => tokens.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)tokens).GetEnumerator();
    }
}
