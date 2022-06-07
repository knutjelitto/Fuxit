using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    internal class FieldPattern : Field
    {
        public FieldPattern(Expression pattern)
        {
            Pattern = pattern;
        }

        public Expression Pattern { get; }

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
