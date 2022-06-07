using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    internal class ExposedType : Exposed
    {
        public ExposedType(Identifier name, bool inclusive)
            : base(name)
        {
            Assert(name.IsSingle(Lex.UpperId));
            Inclusive = inclusive;
        }

        public bool Inclusive { get; }

        public override string ToString()
        {
            if (Inclusive)
            {
                return $"{Name}{Lex.Weak.ExposeAll}";
            }
            return $"{Name}";
        }
    }
}
