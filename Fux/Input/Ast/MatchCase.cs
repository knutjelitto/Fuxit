using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Building;

namespace Fux.Input.Ast
{
    internal class MatchCase : Expression
    {
        public MatchCase(SequenceExpr pattern, Expression expression)
        {
            Pattern = pattern;
            Expression = expression;
        }

        public SequenceExpr Pattern { get; }
        public Expression Expression { get; }

        public LetScope Scope { get; } = new();

        public override string ToString()
        {
            return $"{Pattern} {Lex.Arrow} {Expression}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Pattern} {Lex.Arrow} ");
            Expression.PP(writer);
            writer.EndLine();
        }
    }
}
