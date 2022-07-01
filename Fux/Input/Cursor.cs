using System.Runtime.CompilerServices;

using Fux.Building;

namespace Fux.Input
{
    public sealed class Cursor
    {
        public Cursor(Module module, ParserErrors error, Tokens tokens)
        {
            Assert(tokens.Count > 0);
            Offset = 0;
            Module = module;
            Error = error;
            Tokens = tokens;
        }

        public int Offset { get; private set; }
        public Module Module { get; }
        public ParserErrors Error { get; }
        public Tokens Tokens { get; }

        public bool StartsAtomic => More() && Current.Lex.StartsAtomic;

        public bool StartsTypeAnnotation
        {
            get
            {
                return
                    Tokens[Offset].Lex == Lex.LowerId &&
                    Offset + 1 < Tokens.Count &&
                    Tokens[Offset + 1].Lex == Lex.Colon;
            }
        }

        public bool StartsPrefix
        {
            get
            {
                var hasPrev = Offset > 0;
                var hasNext = Offset + 1 < Tokens.Count;

                return
                    hasNext &&
                    Current.Text == "-" &&
                    !Next.WhitesBefore &&
                    this.IsOperator() &&
                    (Current.WhitesBefore || (hasPrev && Prev.Lex.IsParent));
            }
        }

        public bool StartsInfix
        {
            get
            {
                return
                    this.IsOperator() &&
                    !StartsPrefix;
            }
        }

        public int State => Offset;

        public void Reset(int state)
        {
            Offset = state;
        }

        public int Line => Current.Location.Line;
        public int Column => Current.Location.Column;

        public Token Current
        {
            get
            {
                Assert(Offset < Tokens.Count);

                return Tokens[Offset];
            }
        }

        public Token Next
        {
            get
            {
                Assert(Offset + 1 < Tokens.Count);

                return Tokens[Offset + 1];
            }
        }


        public Token Prev
        {
            get
            {
                Assert(Offset > 0);

                return Tokens[Offset - 1];
            }
        }

        public T Scope<T>(Func<Cursor, T> parser)
            where T : A.Node
        {
            var start = Tokens.Start + Offset;
            var expression = parser(this);
            var next = Tokens.Start + Offset;

            expression.InModule = Module;
            expression.Span = new Tokens(Tokens.Toks, start, next);

            return expression;
        }

        public Cursor Subcursor()
        {
            Assert(Current.First);

            var subs = new Tokens(Tokens.Toks, Current.Index, Current.Index);

            var indent = Current.Indent;

            while (More() && Current.Indent == indent)
            {
                var current = Current;

                subs.Add();

                Advance();

                if (current.Last)
                {
                    break;
                }
            }

            Assert(subs[^1].Last);

            while (More() && Current.Indent > indent)
            {
                subs.Add();
                Advance();
            }

            return new Cursor(Module, Error, subs);
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

        public bool TerminatesSomething => Offset < Tokens.Count && Tokens[Offset].Lex.TerminatesSomething;

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
