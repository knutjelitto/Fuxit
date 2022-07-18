namespace Fux.Tools
{
    public sealed class Path
    {
        public Path(params string[] parts)
        {
            Name = IO.Path.Combine(parts).Replace('\\', '/');
        }

        public string Name { get; }

        public static implicit operator string(Path folder)
        {
            return folder.Name;
        }

        public static Path Combine(params string[] parts)
        {
            return new Path(parts);
        }

        public override string ToString() => Name;
    }
}
