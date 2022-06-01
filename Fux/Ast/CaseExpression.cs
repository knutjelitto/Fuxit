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
            var cases = string.Join(" ", Cases.Select(x => $"{Lex.GroupOpen} {x} {Lex.GroupClose}"));
            return $"case {Pattern} of {cases}";
        }

        public override void PP(Writer writer)
        {
            if (writer.LineRunning)
            {
                writer.WriteLine();
            }
            writer.Write($"{Lex.HardKwCase} ");
            Pattern.PP(writer);
            writer.WriteLine($" {Lex.HardKwOf}");
            writer.Indent(() =>
            {
                foreach (var casee in Cases)
                {
                    casee.PP(writer);
                    if (writer.LineRunning)
                    {
                        writer.WriteLine();
                    }
                }
            });
        }
    }
}
