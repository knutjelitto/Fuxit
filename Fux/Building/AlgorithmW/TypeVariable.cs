namespace Fux.Building.AlgorithmW
{
    public sealed record TypeVariable(int ID)
    {
        public override string ToString() => $"'t{ID}";
    }
}
