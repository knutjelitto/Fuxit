using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    internal class Parameters : ListOf<Expression>
    {
        public Parameters(IEnumerable<Expression> items)
            : base(items)
        {
        }

        public Parameters()
            : this(Enumerable.Empty<Expression>())
        {
        }

        public override string ToString()
        {
            return $"{string.Join(' ', this)}";
        }
    }
}
