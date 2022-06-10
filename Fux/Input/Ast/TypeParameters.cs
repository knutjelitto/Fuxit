﻿namespace Fux.Input.Ast
{
    internal class TypeParameters : ListOf<Identifier>
    {
        public TypeParameters(IEnumerable<Identifier> items)
            : base(items)
        {
        }

        public TypeParameters(params Identifier[] items)
            : this(items.AsEnumerable())
        {
        }

        public override string ToString()
        {
            return String.Join(" ", this);
        }
    }
}
