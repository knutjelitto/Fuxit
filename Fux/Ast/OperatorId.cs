using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class OperatorId : Symbol
    {
        public OperatorId(Token token)
            : base(token)
        {
        }
    }
}
