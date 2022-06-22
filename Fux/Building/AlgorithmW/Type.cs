namespace Fux.Building.AlgorithmW
{
    internal abstract record Type;

    internal record VariableType(TypeVariable TypeVar) : Type
    {
        public override string ToString() => TypeVar.ToString();
    }

    internal sealed record FunctionType(Type InType, Type OutType) : Type
    {
        public override string ToString() => $"({InType} → {OutType})";
    }

    internal abstract record TupleType(IReadOnlyList<Type> Types) : Type;

    internal sealed record Tuple2Type(Type Type1, Type Type2) : TupleType(new Type[] { Type1, Type2 })
    {
        public override string ToString()
        {
            return $"({Type1}, {Type2})";
        }
    }

    internal sealed record Tuple3Type(Type Type1, Type Type2, Type Type3) : TupleType(new Type[] { Type1, Type2, Type3 })
    {
        public override string ToString()
        {
            return $"({Type1}, {Type2}, {Type3})";
        }
    }

    internal record PrimitiveType(string Name) : Type
    {
        public override string ToString() => Name;
    }

    internal sealed record IntegerType() : PrimitiveType(Lex.Primitive.Int)
    {
        public override string ToString() => Name;
    }

    internal sealed record FloatType() : PrimitiveType(Lex.Primitive.Float)
    {
        public override string ToString() => Name;
    }

    internal sealed record BoolType() : PrimitiveType(Lex.Primitive.Bool)
    {
        public override string ToString() => Name;
    }

    internal sealed record StringType() : PrimitiveType(Lex.Primitive.String)
    {
        public override string ToString() => Name;
    }
}
