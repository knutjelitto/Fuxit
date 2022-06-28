namespace Fux.Building.AlgorithmW
{
    public abstract record TypeVariable;

    public sealed record GenTypeVariable(int ID) : TypeVariable
    {
        public override string ToString() => $"'t{ID}";
    }

    public sealed record FixTypeVariable(string ID) : TypeVariable
    {
        public override string ToString() => ID;
    }
}
