using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class ApplicationExpression : Expression
    {
        public ApplicationExpression(Expression symbol, params Expression[] expressions)
        {
            Symbol = symbol;
            Expressions = expressions;
        }

        public Expression Symbol { get; }
        public IReadOnlyList<Expression> Expressions { get; }
        public override bool IsAtomic => Symbol.IsAtomic && Expressions.Count == 0;

        public override string ToString()
        {
            var joined = string.Join(" ", Expressions);

            return $"{Symbol} {joined}";
        }
    }
}
