using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    public sealed class FieldPattern : Field
    {
        public FieldPattern(Expr pattern)
        {
            Pattern = pattern;
        }

        public Expr Pattern { get; }

        public override string ToString()
        {
            return $"{Pattern}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Pattern}");
        }
    }
}
