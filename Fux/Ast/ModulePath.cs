using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class ModulePath : Expression
    {
        public ModulePath(IReadOnlyList<Identifier> names)
        {
            Names = names;
        }

        public IReadOnlyList<Identifier> Names { get; }

        public override bool IsAtomic => true;

        public override string ToString()
        {
            return String.Join(" . ", Names);
        }
    }
}
