using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class ParseLexer : ILexer
    {
        private int index;
        public ParseLexer(List<Tokens> lines)
        {
            Lines = lines;
            index = 0;
        }

        public List<Tokens> Lines { get; }

        public Tokens GetLine()
        {
            return Lines[index++];
        }

        public IEnumerator<Tokens> GetEnumerator() => Lines.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
