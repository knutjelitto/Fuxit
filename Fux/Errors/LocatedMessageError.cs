using Fux.Input;

namespace Fux.Errors
{
    public abstract class LocatedMessageError : Error
    {
        public LocatedMessageError(ILocation location, string message)
        {
            Location = location;
            Message = message;
        }

        public ILocation Location { get; }
        public string Message { get; }

        public override IEnumerable<string> Report()
        {
            yield return $"{Location.Source.Path}({Location.Line},{Location.Column}): {Message}";
        }
    }
}
