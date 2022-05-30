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

        public static OperatorSymbol Arrow(Token token) => new ArrowOp(token);
        public static OperatorSymbol Select(Token token) => new SelectOp(token);

        public class ArrowOp : OperatorSymbol
        {
            public ArrowOp(Token token) : base(token) { }

            public override Expression Combine(Expression lhs, Expression rhs)
            {
                return new ArrowExpression(this, lhs, rhs);
            }
        }

        public class SelectOp : OperatorSymbol
        {
            public SelectOp(Token token) : base(token) { }

            public override Expression Combine(Expression lhs, Expression rhs)
            {
                return new SelectExpr(this, lhs, rhs);
            }
        }
    }
}
