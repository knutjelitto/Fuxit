namespace Fux.Building.AlgorithmW
{
    public interface WithStructure
    {
        Type At(int index);
    }

    public abstract record Type
    {
        public sealed record Variable(TypeVariable TypeVar) : Type
        {
            public override string ToString() => $"{TypeVar}";
        }

        public sealed record Function(Type InType, Type OutType) : Type
        {
            public override string ToString()
            {
                var start = InType is Function ? $"({InType})" : $"{InType}";

                if (OutType is Function outFunction)
                {
                    return $"{start} → {outFunction.InType} → {outFunction.OutType}";
                }
                return $"{start} → {OutType}";
            }
        }

        public abstract record Tuple(IReadOnlyList<Type> Types) : Type, WithStructure
        {
            public Type At(int index) => Types[index];
        }

        public sealed record Tuple2(Type Type1, Type Type2) : Tuple(new Type[] { Type1, Type2 })
        {
            public override string ToString()
            {
                return $"({Type1}, {Type2})";
            }
        }

        public sealed record Tuple3(Type Type1, Type Type2, Type Type3) : Tuple(new Type[] { Type1, Type2, Type3 })
        {
            public override string ToString()
            {
                return $"({Type1}, {Type2}, {Type3})";
            }
        }

        public sealed record List(Type Type) : Type, WithStructure
{
            public Type At(int index)
            {
                if (index == 0)
                {
                    return Type;
                }

                return this;
            }

            public override string ToString() => $"{Lex.Primitive.List}<{Type}>";
        }

        public sealed record Concrete(string Name, IReadOnlyList<Type> Arguments) : Type
        {
            public Concrete(string Name) : this(Name, Array.Empty<Type>())
            {
                if (Name == "Bool")
                {
                    Assert(false);
                }
            }

            public override string ToString() => $"{Name}{StrArguments}";

            private string StrArguments
            {
                get
                {
                    if (Arguments != null && Arguments.Count > 0)
                    {
                        return $"<{string.Join(", ", Arguments)}>";
                    }
                    return "";
                }
            }
        }

        public sealed record Field(string Name, Type Type)
        {
            public override string ToString()
            {
                return $"{Name} : {Type}";
            }
        }

        public sealed record Record(IReadOnlyList<Field> Fields) : Type
        {
            public override string ToString()
            {
                var fields = string.Join(", ", Fields);
                return $"{{{fields}}}";
            }
        }

        public abstract record Primitive(string Name) : Type
        {
            public override string ToString() => Name;
        }

        public sealed record Unit() : Primitive(Lex.Symbol.Unit)
        {
            public override string ToString() => Name;
        }

        public sealed record Integer() : Primitive(Lex.Primitive.Int)
        {
            public override string ToString() => Name;
        }

        public sealed record Float() : Primitive(Lex.Primitive.Float)
        {
            public override string ToString() => Name;
        }

        public sealed record Bool() : Primitive(Lex.Primitive.Bool)
        {
            public override string ToString() => Name;
        }

        public sealed record String() : Primitive(Lex.Primitive.String)
        {
            public override string ToString() => Name;
        }

        public sealed record Char() : Primitive(Lex.Primitive.Char)
        {
            public override string ToString() => Name;
        }
    }
}
