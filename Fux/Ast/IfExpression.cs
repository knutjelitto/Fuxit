using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class IfExpression : Expression
    {
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
    }
}
