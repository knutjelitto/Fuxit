namespace Fux.Input
{
    public sealed class Location : ILocation
    {
        private (int line, int column)? lineColumn = null;

        public Location(ISource source, int offset, int length)
        {
            Source = source;
            Offset = offset;
            Length = length;
        }

        public ISource Source { get; }
        public int Offset { get; }
        public int Length { get; }
        public int Next => Offset + Length;

        public string Name => Source.Display;
        public int Line => (lineColumn ??= Source.GetLineColumn(Offset)).line;
        public int Column => (lineColumn ??= Source.GetLineColumn(Offset)).column;

        public string Text => Source.GetText(this);

        public override string ToString()
        {
            return $"{Source.Path}({Line},{Column})";
        }
    }
}
