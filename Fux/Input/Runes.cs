using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class Runes : IReadOnlyList<Rune>
    {
        private readonly List<Rune> runes;

        public Runes(IEnumerable<Rune> runes)
        {
            this.runes = new List<Rune>(runes);
        }

        public Rune this[int index] => runes[index];
        public int Count => runes.Count;
        public IEnumerator<Rune> GetEnumerator() => runes.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)runes).GetEnumerator();

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var rune in runes)
            {
                if (rune.Value == '\n')
                {
                    builder.Append("\\n");
                }
                else if (rune.Value == '\r')
                {
                    builder.Append("\\r");
                }
                else
                {
                    builder.Append(char.ConvertFromUtf32(rune.Value));
                }
            }
            return builder.ToString();
        }
    }
}
