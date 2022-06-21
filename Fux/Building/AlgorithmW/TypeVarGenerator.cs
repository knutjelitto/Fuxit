namespace Fux.Building.AlgorithmW
{
    internal class TypeVarGenerator
    {
        private int supply = 0;
        public VariableType GetNext(string? name = null) => new VariableType(new TypeVariable(supply++, name));
    }
}
