using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class OpExpr
    {
        public OpExpr(Operator op, Expression expression)
        {
            Op = op;
            Expression = expression;
        }

        public Operator Op { get; }
        public Expression Expression { get; }

        public override string ToString()
        {
            return $"{Op} {Expression}";
        }
    }
}
