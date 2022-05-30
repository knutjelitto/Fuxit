using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class Imports : ListOf<Import>
    {
        public Imports(IEnumerable<Import> imports)
            : base(imports)
        {
        }
    }
}
