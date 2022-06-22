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
        public ParseLexer(ISource source, List<Tokens> lines)
        {
            Lines = lines;
            Source = source;
            index = 0;
        }

        public List<Tokens> Lines { get; }

        public ISource Source { get; }

        public Tokens GetLine()
        {
            return Lines[index++];
        }

        public IEnumerator<Tokens> GetEnumerator() => Lines.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
