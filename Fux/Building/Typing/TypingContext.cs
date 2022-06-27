using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Building.Typing
{
    internal class TypingContext
    {
        private readonly IdentityDictionary<A.Expr, A.Expr> mapper = new();
    }
}
