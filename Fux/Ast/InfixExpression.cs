using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class InfixExpression : Expression
    {
        public InfixExpression(OperatorSymbol op, Expression lhs, Expression rhs)
        {
            Op = op;
            Lhs = lhs;
            Rhs = rhs;
        }

        public OperatorSymbol Op { get; }
        public Expression Lhs { get; }
        public Expression Rhs { get; }

        public override bool IsAtomic => true;

        public override string ToString()
        {
            return $"{Lhs} {Op.Text} {Rhs}";
        }
    }
}
