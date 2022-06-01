using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Semver;

namespace Fux.ElmPackages
{
    internal class ElmPackage
    {
        private Elm? elm = null;

        public ElmPackage(string name, SemVersion version)
        {
            Name = name;
            Version = version;
        }

        public ElmPackage(string name, string version)
            : this(name, SemVersion.Parse(version, SemVersionStyles.Strict))
        {
        }

        public string Name { get; }
        public SemVersion Version { get; }
        public string FullName => $"{Name}/{Version}";
        public Elm Elm => elm ??= GetElm();
        public string RootPath => Temp.ElmPath(FullName);

        public static ElmPackage Latest(string packageName)
        {
            return Catalog.Instance.Latest(packageName);
        }

        public override string ToString()
        {
            return FullName;
        }

        private Elm GetElm()
        {
            var elmFile = Path.Combine(RootPath, "elm.json").Replace('\\', '/');

            if (!File.Exists(elmFile))
            {
                Provide();
            }

            return Elm.From(this, File.ReadAllBytes(elmFile));
        }

        private void Provide()
        {
            var catalog = Catalog.Instance;

            var reference = catalog.Where(r => r.Name == Name && r.Version == Version).FirstOrDefault();

            if (reference != null)
            {
                var endpoint = Endpoint.Get(reference);

                var archive = Archive.Get(endpoint);

                var tempDestination = Temp.ElmPath(".temp");
                var destinationTop = Temp.ElmPath(reference.Name);
                var destination = Temp.ElmPath(reference.Name) + "/" + reference.Version;

                foreach (var folder in Directory.GetDirectories(tempDestination))
                {
                    Directory.Delete(folder, true);
                }

                Console.Write($"extracting {destination} ...");

                ZipFile.ExtractToDirectory(archive, tempDestination, true);

                var source = Directory.GetDirectories(tempDestination).FirstOrDefault();

                if (source != null)
                {
                    Directory.Delete(destination, true);

                    Directory.CreateDirectory(destinationTop);

                    Directory.Move(source, destination);
                }

                Console.WriteLine();
            }
        }

    }
}
