using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    internal abstract class Exposed
    {
        protected Exposed(Identifier name)
        {
            Name = name;
        }

        public Identifier Name { get; }
    }
}
