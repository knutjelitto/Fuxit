using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class LineCursor
    {
        public LineCursor(Line line)
        {
            Assert(line.Tokens.Count > 0);

            Line = line;
            Offset = 0;
        }

        public Line Line { get; }
        public int Offset { get; private set; }
        public int Lenght => Line.Tokens.Count;

        public int LineCount => Line.Lines.Count;
        public LineCursor this[int index] => new LineCursor(Line.Lines[index]);

        public Token Current
        {
            get
            {
                Assert(Offset < Line.Tokens.Count);

                return Line.Tokens[Offset];
            }
        }

        public Token Advance()
        {
            Assert(Offset < Line.Tokens.Count);

            return Line.Tokens[Offset++];

        }

        public bool More()
        {
            return Offset < Line.Tokens.Count;
        }

        public Token Last()
        {
            return Line.Tokens.Last();
        }

        public Token Second()
        {
            return Line.Tokens.Skip(1).First();
        }
    }
}
