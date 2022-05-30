using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class AnnotateExpression : InfixExpression
    {
        public AnnotateExpression(OperatorSymbol op, Expression lhs, Expression rhs)
            : base(op, lhs, rhs)
        {
            Assert(op.Token.Lex == Lex.Colon);
        }

        public override bool IsAtomic => true;

        public override string ToString()
        {
            return $"{Lhs} {Op.Text} {Rhs}";
        }
    }
}
