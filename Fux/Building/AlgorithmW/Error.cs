namespace Fux.Building.AlgorithmW
{
    public record Error(string Message)
    {
        public override string ToString() => Message;
    }

    public class WError : Exception
    {
        public WError(Error error) : base(error.Message)
        {
        }

        public WError(string message) : base(message)
        {
        }
    }
}
