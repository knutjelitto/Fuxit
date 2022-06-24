using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Building;

namespace Fux.Input.Ast
{
    internal class LetAssign : Expression
    {
        public LetAssign(SequenceExpr pattern, Expression expression)
        {
            Pattern = pattern;
            Expression = expression;

            Collector.Instance.Pattern.Add(pattern);
        }

        public SequenceExpr Pattern { get; }
        public Expression Expression { get; }
        public LetScope Scope { get; } = new();

        public override string ToString()
        {
            return $"{Pattern} {Lex.Assign} {Expression}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Pattern} {Lex.Assign} ");
            Expression.PP(writer);
            writer.EndLine();
        }
    }
}
