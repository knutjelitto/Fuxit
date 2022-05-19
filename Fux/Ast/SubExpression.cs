using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class SubExpression : Atom
    {
        public SubExpression(Token left, Token right, Expression expression)
        {
            Left = left;
            Right = right;
            Expression = expression;
        }

        public Token Left { get; }
        public Token Right { get; }
        public Expression Expression { get; }
    }
}
