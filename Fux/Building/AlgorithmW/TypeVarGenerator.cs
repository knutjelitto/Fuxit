namespace Fux.Building.AlgorithmW
{
    internal class TypeVarGenerator
    {
        private int supply = 0;
        public VariableType GetNext() => new VariableType(new TypeVariable(supply++));
    }
}
