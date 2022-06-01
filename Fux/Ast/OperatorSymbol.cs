using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class OperatorSymbol : Symbol
    {
        public OperatorSymbol(Token token) : base(token)
        {
        }

        public string Text => Token.ToString();

        public override string ToString()
        {
            return $"({Token})";
        }

        public virtual Expression Combine(Expression lhs, Expression rhs)
        {
            return new InfixExpression(this, lhs, rhs);
        }
    }
}
