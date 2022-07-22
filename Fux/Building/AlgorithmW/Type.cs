namespace Fux.Building.AlgorithmW
{
    public interface WithStructure
    {
        Type At(int index);
    }

    public abstract class Type
    {
        public sealed class Variable : Type
        {
            public Variable(TypeVariable typeVar)
            {
                TypeVar = typeVar;
            }

            public TypeVariable TypeVar { get; }

            public void Deconstruct(out TypeVariable typeVar)
            {
                typeVar = TypeVar;
            }

            public override string ToString() => $"{TypeVar}";
        }

        public sealed class Function : Type
        {
            public Function(Type inType, Type outType)
            {
                InType = inType;
                OutType = outType;
            }

            public Type InType { get; }
            public Type OutType { get; }

            public void Deconstruct(out Type inType, out Type outType)
            {
                inType = InType;
                outType = OutType;
            }

            public override string ToString()
            {
                var start = InType is Function ? $"({InType})" : $"{InType}";

                return $"{start} → {OutType}";
            }
        }

        public abstract class Tuple : Type, WithStructure
        {
            protected Tuple(params Type[] types)
            {
                Types = types;
            }

            public IReadOnlyList<Type> Types { get; }

            public Type At(int index) => Types[index];

            public override string ToString()
            {
                var types = string.Join(", ", Types);
                return $"({types})";
            }
        }

        public sealed class Tuple2 : Tuple
        {
            public Tuple2(Type type1, Type type2)
                : base(type1, type2)
            {
            }

            public Type Type1 => Types[0];
            public Type Type2 => Types[1];

            public void Deconstruct(out Type type1, out Type type2)
            {
                type1 = Type1;
                type2 = Type2;
            }
        }

        public sealed class Tuple3 : Tuple
        {
            public Tuple3(Type type1, Type type2, Type type3)
                : base(type1, type2, type3)
            {
            }

            public Type Type1 => Types[0];
            public Type Type2 => Types[1];
            public Type Type3 => Types[2];

            public void Deconstruct(out Type type1, out Type type2, out Type type3)
            {
                type1 = Type1;
                type2 = Type2;
                type3 = Type3;
            }
        }

        public sealed class List : Type, WithStructure
        {
            public List(Type type)
            {
                Type = type;
            }

            public Type Type { get; }

            public Type At(int index)
            {
                if (index == 0)
                {
                    return Type;
                }

                return this;
            }

            public void Deconstruct(out Type type)
            {
                type = Type;
            }

            public override string ToString() => $"{Lex.Primitive.List}<{Type}>";
        }

        public sealed class Custom : Type
        {
            public Custom(string name, IReadOnlyList<Type> arguments)
            {
                Name = name;
                Arguments = arguments;
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

            public string Name { get; }
            public IReadOnlyList<Type> Arguments { get; }
        }

        public sealed record Field(string Name, Type Type)
        {
            public override string ToString()
            {
                return $"{Name} : {Type}";
            }
        }

        public sealed class Record : Type
        {
            public Record(IReadOnlyList<Field> fields)
            {
                Fields = fields;
            }

            public IReadOnlyList<Field> Fields { get; }

            public override string ToString()
            {
                var fields = string.Join(", ", Fields);
                return $"{{{fields}}}";
            }

            public void Deconstruct(out IReadOnlyList<Field> fields)
            {
                fields = Fields;
            }
        }

        public abstract class Primitive : Type
        {
            protected Primitive(string name)
            {
                Name = name;
            }

            public string Name { get; }

            public override string ToString() => Name;
        }

        public sealed class Unit : Primitive
        {
            public Unit() : base(Lex.Symbol.Unit) { }
        }

        public sealed class Integer : Primitive
        {
            public static readonly Integer Instance = new();

            private Integer() : base(Lex.Primitive.Int) { }
        }

        public sealed class Float : Primitive
        {
            public static readonly Float Instance = new();

            private Float() : base(Lex.Primitive.Float) { }
        }

        public sealed class Bool : Primitive
        {
            public static readonly Bool Instance = new();

            private Bool() : base(Lex.Primitive.Bool) { }
        }

        public sealed class String : Primitive
        {
            public static readonly String Instance = new();

            private String() : base(Lex.Primitive.String) { }
        }

        public sealed class Char : Primitive
        {
            public static readonly Char Instance = new();

            private Char() : base(Lex.Primitive.Char) { }
        }
    }
}
