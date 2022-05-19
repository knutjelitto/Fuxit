using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class Unit : Atom
    {
        public Unit(Token left, Token right)
        {
            Left = left;
            Right = right;
        }

        public Token Left { get; }
        public Token Right { get; }
    }
}
