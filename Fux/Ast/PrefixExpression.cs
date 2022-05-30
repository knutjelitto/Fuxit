using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class PrefixExpression : Expression
    {
        public PrefixExpression(OperatorSymbol op, Expression rhs)
        {
            Op = op;
            Rhs = rhs;
        }

        public OperatorSymbol Op { get; }
        public Expression Rhs { get; }

        public override bool IsAtomic => true;

        public override string ToString()
        {
            return $"{Op.Text} {Rhs}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{this}");
        }
    }
}
