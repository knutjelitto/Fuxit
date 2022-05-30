using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class Declarations : ListOf<Expression>
    {
        public Declarations(IEnumerable<Expression> items)
            : base(items)
        {
        }
    }
}
