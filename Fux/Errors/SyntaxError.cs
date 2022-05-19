namespace Fux.Errors
{
    public class SyntaxError : LocatedMessageError
    {
        public SyntaxError(ILocation location, string message)
            : base(location, message)
        {
        }
    }
}
