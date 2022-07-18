using System.IO.Compression;

using Semver;

namespace Fux.ElmPackages
{
    public sealed class Package : IPackage
    {
        private ElmJson? elm = null;

        public Package(string name, SemVersion version)
        {
            Name = name;
            Version = version;
        }

        public Package(string name, string version)
            : this(name, SemVersion.Parse(version, SemVersionStyles.Strict))
        {
        }

        public string Name { get; }
        public SemVersion Version { get; }
        public string FullName => $"{Name.ToLower()}/{Version}";
        public ElmJson Elm => elm ??= GetElm();
        public string RootPath => IsFux ? Temp.FuxPath(FullName) : Temp.ElmPath(FullName);
        public bool IsFux => FullName.StartsWith("fux/");

        public static Package Latest(string packageName)
        {
            return Catalog.Instance.Latest(packageName);
        }

        public override string ToString()
        {
            return FullName;
        }

        private ElmJson GetElm()
        {
            var elmFile = IO.Path.Combine(RootPath, "elm.json").Replace('\\', '/');

            if (!IO.File.Exists(elmFile))
            {
                Provide();
            }

            return ElmJson.From(this, IO.File.ReadAllBytes(elmFile));
        }

        private void Provide()
        {
            var catalog = Catalog.Instance;

            var reference = catalog.Where(r => r.Name == Name && r.Version == Version).FirstOrDefault();

            if (reference != null)
            {
                var endpoint = EndpointJson.Get(reference);

                var archive = Archive.Get(endpoint);

                var tempDestination = Temp.ElmPath(".temp");
                var destinationTop = Temp.ElmPath(reference.Name);
                var destination = Temp.ElmPath(reference.Name) + "/" + reference.Version;

                foreach (var folder in IO.Directory.GetDirectories(tempDestination))
                {
                    IO.Directory.Delete(folder, true);
                }

                Terminal.Write($"extracting {destination} ...");

                ZipFile.ExtractToDirectory(archive, tempDestination, true);

                var source = IO.Directory.GetDirectories(tempDestination).FirstOrDefault();

                if (source != null)
                {
                    IO.Directory.Delete(destination, true);

                    IO.Directory.CreateDirectory(destinationTop);

                    IO.Directory.Move(source, destination);
                }

                Terminal.WriteLine();
            }
        }

    }
}
