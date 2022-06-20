namespace Fux.Building.AlgorithmW
{
    public class Polytype
    {
        public Polytype(IReadOnlyList<TypeVar> typeVariables, WType type)
        {
            TypeVariables = typeVariables;
            Type = type;
        }

        public Polytype(WType type)
            : this(Array.Empty<TypeVar>(), type)
        {
        }

        public IReadOnlyList<TypeVar> TypeVariables { get; }
        public WType Type { get; }
    }
}
