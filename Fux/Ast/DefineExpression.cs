using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class DefineExpression : Expression
    {
        public DefineExpression(OperatorSymbol op, Expression lhs, Expression rhs)
        {
            Assert(op.Token.Lex == Lex.Define);

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
            return $"{Lhs} {Op.Text} {Rhs}";
        }
    }
}
