namespace Fux.Building.AlgorithmW
{
    public sealed class TypeVariable
    {
        public TypeVariable(int id, string? name = null)
        {
            ID = id;
            Name = name;
        }

        public int ID { get; }
        public string? Name { get; }

        public override string ToString() => Name ?? $"'t{ID}";
        public override bool Equals(object? obj) => obj is TypeVariable other && other.ID == ID;
        public override int GetHashCode() => ID.GetHashCode();
    }
}
