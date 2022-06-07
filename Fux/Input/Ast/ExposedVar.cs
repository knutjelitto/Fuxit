using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    internal class ExposedVar : Exposed
    {
        public ExposedVar(Identifier name)
            : base(name)
        {
            Assert(name.IsSingle(Lex.LowerId) || name.IsSingle(Lex.OperatorId));
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
