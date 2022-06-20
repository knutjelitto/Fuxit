namespace Fux.Building.AlgorithmW
{
    public record Error(string Message)
    {
        public override string ToString() => Message;
    }
}
