namespace Fux.Building.AlgorithmW
{
    public sealed class Polytype
    {
        public Polytype(Type type, IReadOnlyList<TypeVariable> typeVariables)
        {
            TypeVariables = typeVariables;
            Type = type;
        }

        public Polytype(Type type)
            : this(type, Array.Empty<TypeVariable>())
        {
        }

        public Type Type { get; }
        public IReadOnlyList<TypeVariable> TypeVariables { get; }

        public override string? ToString()
        {
            return Type?.ToString();
        }
    }
}
