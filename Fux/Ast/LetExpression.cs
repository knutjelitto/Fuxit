using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class LetExpression : Expression
    {
        public LetExpression(IReadOnlyList<Expression> letExpressions, Expression inExpression)
        {
            LetExpressions = letExpressions;
            InExpression = inExpression;
        }

        public IReadOnlyList<Expression> LetExpressions { get; }
        public Expression InExpression { get; }

        public override bool IsAtomic => false;
    }
}
