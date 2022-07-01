namespace Fux.Building.AlgorithmW
{
    public sealed record TypeVariable(int ID, string? Name = null)
    {
        public override string ToString()
        {
            if (Name != null)
            {
                return $"{Name}";
            }
            return $"'t{ID}";
        }
    }
}
