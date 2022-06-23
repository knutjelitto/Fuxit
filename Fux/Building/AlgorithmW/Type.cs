namespace Fux.Building.AlgorithmW
{
    internal abstract record Type
    {
        internal record Variable(TypeVariable TypeVar) : Type
        {
            public override string ToString() => TypeVar.ToString();
        }

        internal sealed record Function(Type InType, Type OutType) : Type
        {
            public override string ToString() => $"({InType} → {OutType})";
        }

        internal abstract record Tuple(IReadOnlyList<Type> Types) : Type;

        internal sealed record Tuple2(Type Type1, Type Type2) : Tuple(new Type[] { Type1, Type2 })
        {
            public override string ToString()
            {
                return $"({Type1}, {Type2})";
            }
        }

        internal sealed record Tuple3(Type Type1, Type Type2, Type Type3) : Tuple(new Type[] { Type1, Type2, Type3 })
        {
            public override string ToString()
            {
                return $"({Type1}, {Type2}, {Type3})";
            }
        }

        internal record Primitive(string Name) : Type
        {
            public override string ToString() => Name;
        }

        internal sealed record Integer() : Primitive(Lex.Primitive.Int)
        {
            public override string ToString() => Name;
        }

        internal sealed record Float() : Primitive(Lex.Primitive.Float)
        {
            public override string ToString() => Name;
        }

        internal sealed record Bool() : Primitive(Lex.Primitive.Bool)
        {
            public override string ToString() => Name;
        }

        internal sealed record String() : Primitive(Lex.Primitive.String)
        {
            public override string ToString() => Name;
        }
    }
}
