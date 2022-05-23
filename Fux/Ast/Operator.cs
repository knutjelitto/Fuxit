using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class Operator : Symbol
    {
        public Operator(Token token) : base(token)
        {
        }

        public string Text => Token.ToString();

        public override string ToString()
        {
            return $"({Token})";
        }

        public virtual Expression Combine(Expression lhs, Expression rhs)
        {
            return new ApplicationExpression(this, lhs, rhs);
        }

        public static Operator Arrow(Token token) => new ArrowOp(token);
        public static Operator Select(Token token) => new SelectOp(token);

        public class ArrowOp : Operator
        {
            public ArrowOp(Token token) : base(token) { }

            public override Expression Combine(Expression lhs, Expression rhs)
            {
                return new ArrowExpr(this, lhs, rhs);
            }
        }
        
        public class SelectOp : Operator
        {
            public SelectOp(Token token) : base(token) { }

            public override Expression Combine(Expression lhs, Expression rhs)
            {
                return new SelectExpr(this, lhs, rhs);
            }
        }
    }
}
