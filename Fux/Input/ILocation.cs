namespace Fux.Input
{
    public interface ILocation
    {
        ISource Source { get; }
        int Offset { get; }
        int Length { get; }
        int Next { get; }
        string Name { get; }
        int Line { get; }
        int Column { get; }

        string Text { get; }
    }
}
