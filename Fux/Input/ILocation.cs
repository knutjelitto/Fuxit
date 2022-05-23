namespace Fux.Input
{
    public interface ILocation
    {
        ISource Source { get; }
        int Offset { get; }
        int Length { get; }
        int Next { get; }
        int Line { get; }
        int Column { get; }

        string Text { get; }
    }
}
