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

    internal sealed record IntegerLiteral(long Value) : Literal
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
        public override string ToString() => $"(apply {Exp1} {Exp2})";
    }

    internal sealed record AbstractionExpression(TermVariable Term, Expr Exp) : Expr
    {
        public override string ToString() => $"({Term} => {Exp})";
    }

    internal sealed record UnifyExpression(Type Type, Expr Expr) : Expr
    {
        public override string ToString() => $"(unify {Expr})";
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

    internal abstract record TupleExpression(IReadOnlyList<Expr> Exprs) : Expr;

    internal sealed record Tuple2Expression(Expr Expr1, Expr Expr2) : TupleExpression(new Expr[] {Expr1, Expr2})
    {
        public override string ToString() => $"(tuple {Expr1}, {Expr2})";
    }

    internal sealed record Tuple3Expression(Expr Expr1, Expr Expr2, Expr Expr3) : TupleExpression(new Expr[] { Expr1, Expr2, Expr3 })
    {
        public override string ToString() => $"(tuple {Expr1}, {Expr2}, {Expr3})";
    }

    internal sealed record NativeExpression(A.NativeDecl Native) : Expr
    {
        public override string ToString() => $"(native {Native})";
    }
}
