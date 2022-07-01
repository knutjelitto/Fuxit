namespace Fux.Building.AlgorithmW
{
    public sealed class TypeVarGenerator
    {
        private int supply = 0;

        public Type.Variable GetNext(string? name = null)
        {
            return new Type.Variable(new TypeVariable(supply++, name));
        }
    }
}
