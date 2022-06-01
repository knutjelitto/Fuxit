using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class IfExpression : Expression
    {
        const int whatIsLong = 20;

        public IfExpression(Expression condition, Expression ifTrue, Expression ifFalse)
        {
            Condition = condition;
            IfTrue = ifTrue;
            IfFalse = ifFalse;
        }

        public Expression Condition { get; }
        public Expression IfTrue { get; }
        public Expression IfFalse { get; }

        public override bool IsAtomic => true;

        public override string ToString()
        {
            return $"if {Condition} then {IfTrue} else {IfFalse}";
        }

        public override void PP(Writer writer)
        {
            var longer = false
                || Condition.ToString()!.Length > whatIsLong
                || IfTrue.ToString()!.Length > whatIsLong
                || IfFalse.ToString()!.Length > whatIsLong
                ;

            if (longer)
            {
                if (writer.LineRunning)
                {
                    writer.WriteLine();
                    writer.Indent(Write);
                }
                else
                {
                    Write();
                }

                void Write()
                {
                    writer.WriteLine($"{Lex.HardKwIf}");
                    writer.Indent(() =>
                    {
                        Condition.PP(writer);
                    });
                    writer.WriteLine();
                    writer.WriteLine($"{Lex.HardKwThen}");
                    writer.Indent(() =>
                    {
                        IfTrue.PP(writer);
                    });
                    writer.WriteLine();
                    writer.WriteLine($"{Lex.HardKwElse}");
                    writer.Indent(() =>
                    {
                        IfFalse.PP(writer);
                    });
                    writer.WriteLine();
                }
            }
            else
            {
                writer.Write($"{Lex.HardKwIf} {Condition} {Lex.HardKwThen} {IfTrue} {Lex.HardKwElse} {IfFalse}");
            }
        }
    }
}
