namespace Fux.Building.AlgorithmW
{
    public abstract record Expr
    {
        public sealed record Variable(TermVariable Term) : Expr
        {
            public Variable(A.Identifier name) : this(new TermVariable(name)) { }
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record Application(Expr Exp1, Expr Exp2) : Expr
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record Lambda(TermVariable Term, Expr Exp) : Expr
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record Unify(Type Type, Expr Expr) : Expr
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record Def(Expr.Variable Var, Expr Expr) : Expr
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record Let(TermVariable Term, Expr Expr1, Expr Expr2) : Expr
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public abstract record Tuple(IReadOnlyList<Expr> Exprs) : Expr;

        public sealed record Tuple2(Expr Expr1, Expr Expr2) : Tuple(new Expr[] { Expr1, Expr2 })
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record Tuple3(Expr Expr1, Expr Expr2, Expr Expr3) : Tuple(new Expr[] { Expr1, Expr2, Expr3 })
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record GetValue(Expr Expr, Func<Environment, Polytype> TypeGen, int Index) : Expr
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public abstract record List : Expr;

        public sealed record Empty : List
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record Cons(Expr First, List Rest) : List
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record DeCons(Expr First, Expr Rest) : List
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record DeCtor(Expr First, IReadOnlyList<Expr> Arguments) : List
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record Native(A.Decl.Native Nat) : Expr
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record Iff(Expr Cond, Expr Then, Expr Else) : Expr
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record Matcher(Expr Expr, IReadOnlyList<Case> Cases) : Expr
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record Case(Environment Env, Expr Pattern, Expr Expr) : Expr
        {
            public override string ToString() => Pretty.Expr(this);
        }

        public sealed record Wildcard(string Text) : Expr
        {
            public override string ToString() => Pretty.Expr(this);
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
            new public sealed record Application(IReadOnlyList<Expr> Exprs) : Sugar
            {
                public override string ToString() => Pretty.Expr(this);
            }

            new public sealed record Lambda(IReadOnlyList<TermVariable> Terms, Expr Expr) : Sugar;
        }
    }
}
