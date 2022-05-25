using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class Header : Expression
    {
        public Header(Expression name, TupleExpression exports)
        {
            Name = name;
            Exports = exports;
        }

        public Expression Name { get; }
        public TupleExpression Exports { get; }

        public override bool IsAtomic => false;

        public override string ToString()
        {
            var exports = string.Join(", ", Exports);
            return $"module {Name} exposing ( {exports} )";
        }
    }
}
