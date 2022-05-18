﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class Runes : IReadOnlyList<char>
    {
        private readonly List<char> runes;

        public Runes(IEnumerable<char> runes)
        {
            this.runes = new List<char>(runes);
        }

        public char this[int index] => runes[index];
        public int Count => runes.Count;
        public IEnumerator<char> GetEnumerator() => runes.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)runes).GetEnumerator();

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var rune in runes)
            {
                if (rune == '\n')
                {
                    builder.Append("\\n");
                }
                else if (rune == '\r')
                {
                    builder.Append("\\r");
                }
                else
                {
                    builder.Append(rune);
                }
            }
            return builder.ToString();
        }
    }
}
