using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class ArrowExpr : Expression
    {
        public ArrowExpr(Operator op, Expression from, Expression to)
        {
            Op = op;
            From = from;
            To = to;
        }

        public override bool IsAtomic => From.IsAtomic && (To.IsAtomic || To is ArrowExpr);

        public Operator Op { get; }
        public Expression From { get; }
        public Expression To { get; }

        public override string ToString()
        {
            var from = From.IsAtomic ? From.ToString() : $"({From})";
            var to = To.IsAtomic ? To.ToString() : (To is ArrowExpr ? To.ToString() : $"({To})");
            return $"{from} -> {to}";
        }
    }
}
