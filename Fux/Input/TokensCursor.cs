using System.Runtime.CompilerServices;

namespace Fux.Input
{
    internal class TokensCursor
    {
        public TokensCursor(ParserErrors error, Tokens tokens)
        {
            Assert(tokens.Count > 0);
            Offset = 0;
            Error = error;
            Tokens = tokens;
        }

        public int Offset { get; private set; }
        public ParserErrors Error { get; }
        public Tokens Tokens { get; }
        public bool StartsAtomic => More() && Current.Lex.StartsAtomic;

        public Token Current
        {
            get
            {
                Assert(Offset < Tokens.Count);

                return Tokens[Offset];
            }
        }

        public Token Advance()
        {
            Assert(Offset < Tokens.Count);

            return Tokens[Offset++];

        }

        public bool More()
        {
            return Offset < Tokens.Count;
        }


        public Token Swallow(Lex lexKind, [CallerMemberName] string? member = null)
        {
            if (this.Is(lexKind))
            {
                return Advance();
            }

            throw Error.Unexpected(lexKind, this.At(), member);
        }

    }
}
