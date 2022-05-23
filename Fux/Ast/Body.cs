using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class Body : Expression
    {
        public Body(IReadOnlyList<Expression> expressions)
        {
            Expressions = expressions;
        }

        public IReadOnlyList<Expression> Expressions { get; }

        public override bool IsAtomic => false;
    }
}
