using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class TypeOrExpr : Expression
    {
        public TypeOrExpr(OperatorSymbol op, Expression lhs, Expression rhs)
        {
            Op = op;
            Lhs = lhs;
            Rhs = rhs;
        }

        public override bool IsAtomic => true;

        public OperatorSymbol Op { get; }
        public Expression Lhs { get; }
        public Expression Rhs { get; }

        public override string ToString()
        {
            var lhs = Lhs.IsAtomic ? Lhs.ToString() : $"({Lhs})";
            var rhs = Rhs.IsAtomic ? Rhs.ToString() : $"({Rhs})";
            return $"{lhs} | {rhs}";
        }
    }
}
