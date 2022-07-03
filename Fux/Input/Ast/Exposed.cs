namespace Fux.Input.Ast
{
    public abstract class Exposed
    {
        protected Exposed(Identifier name)
        {
            Name = name;
        }

        public Identifier Name { get; }


        public sealed class Type : Exposed
        {
            public Type(Identifier name, bool inclusive)
                : base(name)
            {
                Assert(name.IsSingleUpper);
                Inclusive = inclusive;
            }

            public bool Inclusive { get; }

            public void Add(Decl.Ctor ctor)
            {
                ((List<Decl.Ctor>)Ctors).Add(ctor);
            }

            public IReadOnlyList<Decl.Ctor> Ctors { get; } = new List<Decl.Ctor>();

            public override string ToString()
            {
                if (Inclusive)
                {
                    return $"{Name}{Lex.Weak.ExposeAll}";
                }
                return $"{Name}";
            }
        }

        public sealed class Var : Exposed
        {
            public Var(Identifier name)
                : base(name)
            {
                Assert(name.IsSingleLower || name.IsSingleOp);
            }

            public override string ToString()
            {
                return $"{Name}";
            }
        }
    }
}
