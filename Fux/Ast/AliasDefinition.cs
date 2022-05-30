using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class AliasDefinition : Expression
    {
        public AliasDefinition(Expression declaration)
        {
            Declaration = declaration;
        }

        public Expression Declaration { get; }

        public override bool IsAtomic => true;

        public override string ToString()
        {
            return $"type alias {Declaration}";
        }

        public override void PP(Writer writer)
        {
            writer.WriteLine($"{this}");
        }
    }
}
