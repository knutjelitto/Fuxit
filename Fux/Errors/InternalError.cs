namespace Fux.Errors
{
    public sealed class InternalError : Error
    {
        public InternalError(string message)
        {
            Message = message;
        }

        public string Message { get; }

        public override IEnumerable<string> Report()
        {
            yield return $"internal error: {Message}";
        }
    }
}
