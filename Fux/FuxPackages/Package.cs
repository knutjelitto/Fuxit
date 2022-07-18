using System.IO.Compression;

using Semver;

namespace Fux.FuxPackages
{
    public sealed class Package : IPackage
    {
        private FuxJson? json = null;

        public Package(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public string FullName => $"{Name.ToLower()}";
        public FuxJson Json => json ??= GetJson();
        public string RootPath => Temp.FuxPath(FullName);

        public override string ToString()
        {
            return FullName;
        }

        private FuxJson GetJson()
        {
            var jsonFile = new Path(RootPath, "fux.json");

            return FuxJson.From(this, IO.File.ReadAllBytes(jsonFile));
        }
    }
}
