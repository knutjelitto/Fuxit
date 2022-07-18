namespace Fux.ElmPackages
{
    public sealed class Module
    {
        public Module(Package package, string name)
        {
            Package = package;
            Name = name;
            NiceName = Package.FullName + "/" + Name.Replace('.', '/');
            FileName = $"src/{Name.Replace('.', '/')}.elm";
            FullFileName = Path.Combine(Package.RootPath, FileName);
        }

        public Package Package { get; }
        public string Name { get; }

        public string NiceName { get; }
        public string FileName { get; }
        public string FullFileName { get; }

        public override string ToString() => Name;
    }
}
