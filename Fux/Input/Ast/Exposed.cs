namespace Fux.Input.Ast
{
    internal abstract class Exposed
    {
        protected Exposed(Identifier name)
        {
            Name = name;
        }

        public Identifier Name { get; }
    }

    internal class ExposedType : Exposed
    {
        public ExposedType(Identifier name, bool inclusive)
            : base(name)
        {
            Assert(name.IsSingle(Lex.UpperId));
            Inclusive = inclusive;
        }

        public bool Inclusive { get; }

        public override string ToString()
        {
            if (Inclusive)
            {
                return $"{Name}{Lex.Weak.ExposeAll}";
            }
            return $"{Name}";
        }
    }

    internal class ExposedVar : Exposed
    {
        public ExposedVar(Identifier name)
            : base(name)
        {
            Assert(name.IsSingle(Lex.LowerId) || name.IsSingle(Lex.OperatorId));
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
