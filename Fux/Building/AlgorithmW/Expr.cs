namespace Fux.Building.AlgorithmW
{
    public abstract record Expr
    {
        public sealed record Variable(TermVariable Term) : Expr
        {
            public Variable(A.Identifier name) : this(new TermVariable(name.Text)) { }
            public override string ToString() => Term;
        }

        public sealed record Usage(Expr Exp1, Expr Exp2) : Expr
        {
            public override string ToString() => $"(apply {Exp1} {Exp2})";
        }

        public sealed record Lambda(TermVariable Term, Expr Exp) : Expr
        {
            public override string ToString() => $"({Term} => {Exp})";
        }

        public sealed record Unify(Type Type, Expr Expr) : Expr
        {
            public override string ToString() => $"{Expr}";
        }

        public sealed record Def(Expr.Variable Var, Expr Expr) : Expr
        {
            public override string ToString() => $"(def {Var} = {Expr})";
        }

        public sealed record Let(TermVariable Term, Expr Exp1, Expr Exp2) : Expr
        {
            public override string ToString() => $"(let {Term} = {Exp1} in {Exp2})";
        }

        public abstract record Tuple(IReadOnlyList<Expr> Exprs) : Expr;

        public sealed record Tuple2(Expr Expr1, Expr Expr2) : Tuple(new Expr[] { Expr1, Expr2 })
        {
            public override string ToString() => $"(tuple {Expr1}, {Expr2})";
        }

        public sealed record Tuple3(Expr Expr1, Expr Expr2, Expr Expr3) : Tuple(new Expr[] { Expr1, Expr2, Expr3 })
        {
            public override string ToString() => $"(tuple {Expr1}, {Expr2}, {Expr3})";
        }

        public abstract record List : Expr;

        public sealed record Empty : List
        {
            public override string ToString() => $"{Lex.Symbol.Empty}";
        }

        public sealed record Cons(Expr First, List Rest) : List
        {
            public override string ToString() => $"({First} {Lex.Symbol.Cons} {Rest})";
        }

        public sealed record Decons(Expr First, Expr Rest) : List
        {
            public override string ToString() => $"({First} {Lex.Symbol.Cons} {Rest})";
        }

        public sealed record Native(A.NativeDecl Nat) : Expr
        {
            public override string ToString() => $"(native {Nat})";
        }

        public sealed record Iff(Expr Cond, Expr Then, Expr Else) : Expr
        {
            public override string ToString() => $"(if {Cond} then {Then} else {Else})";
        }

        public sealed record Matcher(Expr Expr, IReadOnlyList<Expr.Case> Cases) : Expr
        {
            public override string ToString()
            {
                return $"(case {Expr} of {string.Join(" ", Cases)}";
            }
        }

        public sealed record Case(Expr Pattern, Expr Expr) : Expr
        {
            public override string ToString()
            {
                return $"({Pattern} -> {Expr})";
            }
        }

        /// <summary>
        /// A literal value of some primitive
        /// </summary>
        public abstract record Literal : Expr
        {
            public sealed record Integer(long Value) : Literal
            {
                public override string ToString() => Value.ToString();
            }

            public sealed record Float(double Value) : Literal
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

            public sealed record Bool(bool Value) : Literal
            {
                public override string ToString() => Value.ToString();
            }

            public sealed record String(string Value) : Literal
            {
                public override string ToString() => $"\"{Value}\"";
            }

            public sealed record Char(string Value) : Literal
            {
                public override string ToString() => $"\'{Value}\'";
            }
        }

        public abstract record Sugar : Expr
        {
            public sealed record Application(IReadOnlyList<Expr> Exprs) : Sugar
            {
                public override string ToString() => $"($ {string.Join(" ", Exprs)})";
            }
        }
    }
}
