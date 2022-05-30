using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class CaseExpression : Expression
    {   
        public CaseExpression(Expression pattern, IReadOnlyList<Expression> cases)
        {
            Pattern = pattern;
            Cases = cases;
        }

        public override bool IsAtomic => true;

        public Expression Pattern { get; }
        public IReadOnlyList<Expression> Cases { get; }

        public override string ToString()
        {
            var cases = string.Join(" ", Cases.Select(x => $"{Lex.GroupOpen} {x.ToString()} {Lex.GroupClose}"));
            return $"case {Pattern} of {cases}";
        }
    }
}
