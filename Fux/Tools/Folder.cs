namespace Fux.Tools
{
    public sealed class Folder
    {
        public Folder(params string[] parts)
        {
            Name = IO.Path.Combine(parts).Replace('\\', '/');
        }

        public string Name { get; }

        public static implicit operator string(Folder folder)
        {
            return folder.Name;
        }

        public static Folder Combine(params string[] parts)
        {
            return new Folder(parts);
        }

        public override string ToString() => Name;
    }
}
