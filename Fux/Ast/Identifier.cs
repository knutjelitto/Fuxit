using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class Identifier : Symbol
    {
        public Identifier(Token token) : base(token)
        {
        }

        public override string ToString()
        {
            return $"{Token}";
        }
    }
}
