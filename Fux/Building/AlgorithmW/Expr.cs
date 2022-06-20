namespace Fux.Building.AlgorithmW
{
    internal abstract record Expr;

    internal sealed record Variable(TermVariable Term) : Expr
    {
        public override string ToString() => Term;
    }

    /// <summary>
    /// A literal value of some primitive
    /// </summary>
    internal abstract record Literal : Expr;

    internal sealed record IntegerLiteral(int Value) : Literal
    {
        public override string ToString() => Value.ToString();
    }

    internal sealed record FloatLiteral(double Value) : Literal
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

    internal sealed record BoolLiteral(bool Value) : Literal
    {
        public override string ToString() => Value.ToString();
    }

    internal sealed record StringLiteral(string Value) : Literal
    {
        public override string ToString() => $"\"{Value}\"";
    }

    internal sealed record ApplicationExpression(Expr Exp1, Expr Exp2) : Expr
    {
        public override string ToString() => $"({Exp1} {Exp2})";
    }

    internal sealed record AbstractionExpression(TermVariable Term, Expr Exp) : Expr
    {
        public override string ToString() => $"({Term} => {Exp})";
    }

    internal sealed record DefExpression(Variable Variable, Expr Expr) : Expr
    {
        public override string ToString() => $"(def {Variable} = {Expr})";
    }

    internal sealed record LetExpression(TermVariable Term, Expr Exp1, Expr Exp2) : Expr
    {
        public override string ToString() => $"(let {Term} = {Exp1} in {Exp2})";
    }

    internal sealed record IffExpression(Expr Cond, Expr Then, Expr Else) : Expr
    {
        public override string ToString() => $"(if {Cond} then {Then} else {Else})";
    }

    internal sealed record NativeExpression(NativeDecl Native) : Expr
    {
        public override string ToString() => $"(native {Native})";
    }
}
