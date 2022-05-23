using Fux.Input;

namespace Fux.Errors
{
    public class LexerError : LocatedMessageError
    {
        public LexerError(ILocation location, string message)
            : base(location, message)
        {
        }
    }
}
