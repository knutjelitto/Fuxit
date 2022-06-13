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

        public int State => Offset;

        public void Reset(int state)
        {
            Offset = state;
        }

        public Token Current
        {
            get
            {
                Assert(Offset < Tokens.Count);

                return Tokens[Offset];
            }
        }

        public TokensCursor Sub()
        {
            Assert(Current.First);

            var subs = new Tokens(Tokens.Toks, Current.Index, Current.Index);

            var indent = Current.Indent;

            while (More() && Current.Indent == indent)
            {
                var current = Current;

                subs.Add(Advance());

                if (current.Last)
                {
                    break;
                }
            }

            Assert(subs[^1].Last);

            while (More() && Current.Indent > indent)
            {
                subs.Add(Advance());
            }

            return new TokensCursor(Error, subs);
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

        public bool SwallowIf(Lex lexKind)
        {
            if (this.Is(lexKind))
            {
                Advance();

                return true;
            }

            return false;
        }

        public override string ToString()
        {
            if (More())
            {
                return Current.Dbg();
            }
            return "<EOF>";
        }

    }
}
