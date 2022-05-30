using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class Header : Expression
    {
        public Header(ModulePath path, bool isEffect, RecordExpression? where, TupleExpression? exposes)
        {
            Path = path;
            IsEffect = isEffect;
            Where = where;
            Exposes = exposes;
        }

        public ModulePath Path { get; }
        public bool IsEffect { get; }
        public RecordExpression? Where { get; }
        public TupleExpression? Exposes { get; }

        public override bool IsAtomic => false;

        public override string ToString()
        {
            var effect = IsEffect ? "effect " : "";
            var where = Where != null ? $" where {Where}" : "";
            var exports = Exposes == null ? "" : $" {Lex.Weak.Exposing} {Exposes}";
            return $"{effect}module {Path}{where}{exports}";
        }

        public override void PP(Writer writer)
        {
            if (IsEffect)
            {
                writer.Write("effect ");
            }
            writer.Write($"module {Path}");
            if (Where != null)
            {
                writer.Write($" where {Where}");
            }
            if (Exposes != null)
            {
                writer.Write($" {Lex.Weak.Exposing} {Exposes}");
            }
            writer.WriteLine();
        }
    }
}
