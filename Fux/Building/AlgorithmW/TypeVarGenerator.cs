namespace Fux.Building.AlgorithmW
{
    internal class TypeVarGenerator
    {
        private int supply = 0;
        public Type.Variable GetNext()
        {
            return new Type.Variable(new TypeVariable(supply++));
        }
    }
}
