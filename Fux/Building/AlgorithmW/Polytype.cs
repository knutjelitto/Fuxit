namespace Fux.Building.AlgorithmW
{
    internal class Polytype
    {
        public Polytype(IReadOnlyList<TypeVariable> typeVariables, Type type)
        {
            TypeVariables = typeVariables;
            Type = type;
        }

        public Polytype(Type type)
            : this(Array.Empty<TypeVariable>(), type)
        {
        }

        public IReadOnlyList<TypeVariable> TypeVariables { get; }
        public Type Type { get; }
    }
}
