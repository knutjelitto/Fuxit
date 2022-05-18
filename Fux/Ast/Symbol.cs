using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal abstract class Symbol : Atom
    {
        public Symbol(Token token)
        {
            Token = token;
        }

        public Token Token { get; }
    }
}
