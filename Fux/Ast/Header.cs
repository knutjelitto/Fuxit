using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class Header : Expression
    {
        public Header(ModulePath path, bool isEffect, RecordExpression? where, TupleExpression? exports)
        {
            Path = path;
            IsEffect = isEffect;
            Where = where;
            Exports = exports;
        }

        public ModulePath Path { get; }
        public bool IsEffect { get; }
        public RecordExpression? Where { get; }
        public TupleExpression? Exports { get; }

        public override bool IsAtomic => false;

        public override string ToString()
        {
            var effect = IsEffect ? "effect " : "";
            var where = Where != null ? $" where {Where}" : "";
            var exports = Exports == null ? "" : $" exposing {Exports}";
            return $"{effect}module {Path}{where}{exports}";
        }
    }
}
