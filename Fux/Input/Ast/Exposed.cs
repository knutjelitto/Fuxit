namespace Fux.Input.Ast
{
    public abstract class Exposed
    {
        protected Exposed(Identifier name)
        {
            Name = name;
        }

        public Identifier Name { get; }
    }

    public sealed class ExposedType : Exposed
    {
        public ExposedType(Identifier name, bool inclusive)
            : base(name)
        {
            Assert(name.IsSingleUpper);
            Inclusive = inclusive;
        }

        public bool Inclusive { get; }

        public void Add(Type.Constructor ctor)
        {
            ((List<Type.Constructor>)Ctors).Add(ctor);
        }

        public IReadOnlyList<Type.Constructor> Ctors { get; } = new List<Type.Constructor>();

        public override string ToString()
        {
            if (Inclusive)
            {
                return $"{Name}{Lex.Weak.ExposeAll}";
            }
            return $"{Name}";
        }
    }

    public sealed class ExposedVar : Exposed
    {
        public ExposedVar(Identifier name)
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
