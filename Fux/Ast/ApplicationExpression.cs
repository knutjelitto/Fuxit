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
            var exprs = string.Join(" ", Expressions);

            if (Symbol.ToString() == "(:)")
            {
                Assert(Expressions.Count == 2);
                return $"{Expressions[0]} : {Expressions[1]}";
            }
            if (Symbol.ToString() == "(=)")
            {
                Assert(Expressions.Count == 2);
                return $"{Expressions[0]} = {Expressions[1]}";
            }
            return $"(apply {Symbol} {exprs})";
        }
    }
}
