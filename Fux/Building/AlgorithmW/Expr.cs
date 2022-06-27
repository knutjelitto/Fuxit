namespace Fux.Building.AlgorithmW
{
    internal abstract record Expr
    {
        internal sealed record Variable(TermVariable Term) : Expr
        {
            public Variable(A.Identifier name) : this(new TermVariable(name.Text)) { }
            public override string ToString() => Term;
        }

        internal sealed record Application(Expr Exp1, Expr Exp2) : Expr
        {
            public override string ToString() => $"(apply {Exp1} {Exp2})";
        }

        internal sealed record MultiApplication(IReadOnlyList<Expr> Exprs) : Expr
        {
            public override string ToString() => $"(apply {string.Join(" ", Exprs)})";
        }

        internal sealed record Abstraction(TermVariable Term, Expr Exp) : Expr
        {
            public override string ToString() => $"({Term} => {Exp})";
        }

        internal sealed record Unify(Type Type, Expr Expr) : Expr
        {
            public override string ToString() => $"{Expr}";
        }

        internal sealed record Def(Expr.Variable Var, Expr Expr) : Expr
        {
            public override string ToString() => $"(def {Var} = {Expr})";
        }

        internal sealed record Let(TermVariable Term, Expr Exp1, Expr Exp2) : Expr
        {
            public override string ToString() => $"(let {Term} = {Exp1} in {Exp2})";
        }

        internal abstract record Tuple(IReadOnlyList<Expr> Exprs) : Expr;

        internal sealed record Tuple2(Expr Expr1, Expr Expr2) : Tuple(new Expr[] { Expr1, Expr2 })
        {
            public override string ToString() => $"(tuple {Expr1}, {Expr2})";
        }

        internal sealed record Tuple3(Expr Expr1, Expr Expr2, Expr Expr3) : Tuple(new Expr[] { Expr1, Expr2, Expr3 })
        {
            public override string ToString() => $"(tuple {Expr1}, {Expr2}, {Expr3})";
        }

        internal sealed record Empty : Expr
        {
            public override string ToString() => $"{Lex.Symbol.Empty}";
        }

        internal sealed record Native(A.NativeDecl Nat) : Expr
        {
            public override string ToString() => $"(native {Nat})";
        }

        internal sealed record Iff(Expr Cond, Expr Then, Expr Else) : Expr
        {
            public override string ToString() => $"(if {Cond} then {Then} else {Else})";
        }

        /// <summary>
        /// A literal value of some primitive
        /// </summary>
        internal abstract record Literal : Expr
        {
            internal sealed record Integer(long Value) : Literal
            {
                public override string ToString() => Value.ToString();
            }

            internal sealed record Float(double Value) : Literal
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

            internal sealed record Bool(bool Value) : Literal
            {
                public override string ToString() => Value.ToString();
            }

            internal sealed record String(string Value) : Literal
            {
                public override string ToString() => $"\"{Value}\"";
            }
        }
    }
}
