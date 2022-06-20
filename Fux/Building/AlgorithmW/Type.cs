namespace Fux.Building.AlgorithmW
{
    internal abstract record Type;

    internal record VariableType(TypeVariable TypeVar) : Type
    {
        public override string ToString() => TypeVar.ToString();
    }

    internal sealed record FunctionType(Type TypeIn, Type TypeOut) : Type
    {
        public override string ToString() => $"({TypeIn} → {TypeOut})";
    }

    internal record PrimitiveType(string Name) : Type
    {
        public override string ToString() => Name;
    }

    internal sealed record IntegerType() : PrimitiveType("Int");

    internal sealed record FloatType() : PrimitiveType("Float");

    internal sealed record BoolType() : PrimitiveType("Bool");

    internal sealed record StringType() : PrimitiveType("String");
}
