using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    internal class LetAssign : Expression
    {
        public LetAssign(SequenceExpr pattern, Expression expression)
        {
            Pattern = pattern;
            Expression = expression;
        }

        public SequenceExpr Pattern { get; }
        public Expression Expression { get; }

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
