namespace Fux.Building.AlgorithmW
{
    public sealed class TypeVariable
    {
        public TypeVariable(int id)
        {
            ID = id;
        }

        public int ID { get; }

        public override string ToString() => $"'t{ID}";
        public override bool Equals(object? obj) => obj is TypeVariable other && other.ID == ID;
        public override int GetHashCode() => ID.GetHashCode();
    }
}
