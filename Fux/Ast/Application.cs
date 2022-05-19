using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class Application : Expression
    {
        public Application(Expression symbol, params Expression[] expressions)
        {
            Symbol = symbol;
            Expressions = expressions;
        }

        public Expression Symbol { get; }
        public IReadOnlyList<Expression> Expressions { get; }

        public override string ToString()
        {
            var exprs = string.Join(" ", Expressions);
            return $"(apply {Symbol} {exprs})";
        }
    }
}
