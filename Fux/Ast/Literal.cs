using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal abstract class Literal : Atom
    {
        public Literal(Token token)
        {
            Token = token;
        }

        public Token Token { get; }

        public override string ToString()
        {
            return $"{Token}";
        }
    }
}
