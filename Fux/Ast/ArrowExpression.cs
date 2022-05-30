using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class ArrowExpression : InfixExpression
    {
        public ArrowExpression(OperatorSymbol op, Expression lhs, Expression rhs)
            : base(op, lhs, rhs)
        {
        }

        public override bool IsAtomic => Lhs.IsAtomic && (Rhs.IsAtomic || Rhs is ArrowExpression);

        public override string ToString()
        {
            var from = Lhs.IsAtomic ? Lhs.ToString() : $"({Lhs})";
            var to = Rhs.IsAtomic ? Rhs.ToString() : (Rhs is ArrowExpression ? Rhs.ToString() : $"({Rhs})");
            return $"{from} {Op.Text} {to}";
        }

        public override void PP(Writer writer)
        {
            Lhs.PP(writer);
            writer.Write($" {Lex.Arrow} ");
            Rhs.PP(writer);
        }
    }
}
