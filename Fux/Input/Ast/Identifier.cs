﻿namespace Fux.Input.Ast
{
    internal sealed class Identifier : ListOf<Token>, IEquatable<Identifier>
    {
        private string toString;
        private int hashCode;

        public Identifier(IEnumerable<Token> tokens)
            : base(tokens)
        {
            Assert(Count > 0);
            Assert(this.All(token => token.Lex == Lex.LowerId || token.Lex == Lex.UpperId || token.Lex == Lex.OperatorId));

            toString = $"{string.Join('.', this)}";
            hashCode = toString.GetHashCode();
        }

        public Identifier(params Token[] tokens)
            : this(tokens.AsEnumerable())
        {
        }

        public TypeHint? TypeHint { get; set; } = null;

        public bool IsSingle(Lex lex) => Count == 1 && this[0].Lex == lex;
        public bool IsMulti(Lex lex) => this.All(t => t.Lex == lex);

        public bool IsSingleLower => IsSingle(Lex.LowerId);
        public bool IsSingleUpper => IsSingle(Lex.UpperId);
        public bool IsSingleOp => IsSingle(Lex.OperatorId);
        public bool IsMultiUpper => IsMulti(Lex.UpperId);

        public bool IsQualified
        {
            get
            {
                return Count >= 2
                    && this.SkipLast(1).All(t => t.Lex == Lex.UpperId)
                    && this[Count - 1].Lex == Lex.LowerId;
            }
        }

        public (Identifier module, Identifier name) SplitLast()
        {
            return (new Identifier(this.SkipLast(1)), new Identifier(this.TakeLast(1)));
        }
        
        public Identifier SingleLower()
        {
            Assert(IsSingleLower);

            return this;
        }

        public Identifier SingleLowerOrOp()
        {
            Assert(IsSingleLower || IsSingleOp);

            return this;
        }

        public Identifier SingleOp()
        {
            Assert(IsSingleOp);

            return this;
        }

        public Identifier SingleUpper()
        {
            Assert(IsSingleUpper);

            return this;
        }

        public Identifier MultiUpper()
        {
            Assert(IsMultiUpper);

            return this;
        }

        public override bool Equals(object? obj) => obj is Identifier other && toString == other.toString;
        public override int GetHashCode() => hashCode;
        public override string ToString() => toString;

        public override void PP(Writer writer)
        {
            writer.Write(ToString());
        }

        public bool Equals(Identifier? other) => other != null && hashCode == other.hashCode && toString == other.toString;
    }
}
