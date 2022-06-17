using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Building.AlgorithmW
{
    public abstract record WExpr;

    public record Variable(TermVar Term) : WExpr
    {
        public override string ToString() => Term;
    }

    /// <summary>
    /// A literal value of some primitive
    /// </summary>
    public abstract record Literal : WExpr;

    public record IntegerLiteral(int Value) : Literal
    {
        public override string ToString() => Value.ToString();
    }

    public record FloatLiteral(double Value) : Literal
    {
        public override string ToString()
        {
            if (Math.Truncate(Value) == Value)
            {
                return $"{Value}.0";
            }
            return Value.ToString();
        }
    }

    public record BoolLiteral(bool Value) : Literal
    {
        public override string ToString() => Value.ToString();
    }

    public record StringLiteral(string Value) : Literal
    {
        public override string ToString() => $"\"{Value}\"";
    }

    public record ApplicationExpression(WExpr Exp1, WExpr Exp2) : WExpr
    {
        public override string ToString() => $"({Exp1} {Exp2})";
    }

    public record AbstractionExpression(TermVar Term, WExpr Exp) : WExpr
    {
        //public override string ToString() => $"λ{Term}.{Exp}";
        public override string ToString() => $"({Term} => {Exp})";
    }

    public record LetExpression(TermVar Term, WExpr Exp1, WExpr Exp2) : WExpr
    {
        public override string ToString() => $"(let {Term} = {Exp1} in {Exp2})";
    }

    public record IffExpression(WExpr Cond, WExpr Then, WExpr Else) : WExpr
    {
        public override string ToString() => $"(if {Cond} then {Then} else {Else})";
    }
}
