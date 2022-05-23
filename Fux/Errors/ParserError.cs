using Fux.Input;

namespace Fux.Errors
{
    public class ParserError : LocatedMessageError
    {
        public ParserError(ILocation location, string message)
            : base(location, message)
        {
        }
    }
}
