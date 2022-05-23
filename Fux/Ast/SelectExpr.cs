using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class SelectExpr : Expression
    {
        public SelectExpr(Operator op, Expression from, Expression to)
        {
            Op = op;
            From = from;
            To = to;
        }

        public override bool IsAtomic => true;

        public Operator Op { get; }
        public Expression From { get; }
        public Expression To { get; }

        public override string ToString()
        {
            var from = From.IsAtomic ? From.ToString() : $"({From})";
            var to = To.IsAtomic ? To.ToString() : $"({To})";
            return $"{from}.{to}";
        }
    }
}
