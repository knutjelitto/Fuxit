using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Fux.Input;

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

        public override bool IsAtomic => true;

        public override string ToString()
    {
            string joined = string.Join(" ", LetExpressions.Select(x => $"{Lex.GroupOpen} {x.ToString()} {Lex.GroupClose}"));

            return $"let {joined} in {InExpression}";
        }
    }
}
