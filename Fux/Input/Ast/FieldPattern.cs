using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    public sealed class FieldPattern : Field
    {
        public FieldPattern(Identifier name)
        {
            Name = name;
        }

        public Identifier Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Name}");
        }
    }
}
