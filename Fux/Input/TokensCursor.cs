using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class TokensCursor
    {
        public TokensCursor(Tokens tokens)
        {
            Assert(tokens.Count > 0);
            Offset = 0;
            Tokens = tokens;
        }

        public int Offset { get; private set; }
        public int TokenCount => Tokens.Count;

        public Token Current
        {
            get
            {
                Assert(Offset < Tokens.Count);

                return Tokens[Offset];
            }
        }

        public Tokens Tokens { get; }

        public Token Advance()
        {
            Assert(Offset < Tokens.Count);

            return Tokens[Offset++];

        }

        public bool More()
        {
            return Offset < Tokens.Count;
        }

        public Token Last()
        {
            return Tokens.Last();
        }

        public Token Second()
        {
            return Tokens.Skip(1).First();
        }
    }
}
