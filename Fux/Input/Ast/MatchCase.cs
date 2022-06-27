using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Building;

namespace Fux.Input.Ast
{
    internal class MatchCase : Expr
    {
        public MatchCase(Expr pattern, Expr expression)
        {
            Pattern = pattern;
            Expression = expression;

            Collector.Instance.MatchPattern.Add(Pattern);
        }

        public Expr Pattern { get; }
        public Expr Expression { get; }

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
