using System.Collections;
using System.Text.Json;

using Semver;

namespace Fux.ElmPackages
{
    internal class Catalog : IReadOnlyList<Package>
    {
        private readonly List<Package> references;

        public static readonly string Filename = "catalog.json";

        private static Catalog? catalog = null;

        private Catalog(List<Package> references)
        {
            this.references = references;
        }

        public Package Find(Dependency dependency)
        {
            return references.Where(p => p.Name == dependency.Name && dependency.Match(p.Version)).OrderByDescending(p => p.Version).First();
        }

        public Package Latest(string packageName)
        {
            return references
                .Where(p => p.Name == packageName)
                .OrderByDescending(p => p.Version).First();
        }

        public static Catalog Instance => catalog ??= GetCatalog();

        private static Catalog GetCatalog()
        {
            byte[] bytes;

            var filePath = ElmCache.FilePath(Filename);

            if (!File.Exists(filePath))
            {
                bytes = Download();

                File.WriteAllBytes(filePath, bytes);
            }
            else
            {
                bytes = File.ReadAllBytes(filePath);
            }

            return Decode(bytes);
        }

        private static Catalog Decode(byte[] bytes)
        {
            var element = bytes.GetRootElement();

            Assert(element.ValueKind == JsonValueKind.Object);

            var references = new List<Package>();

            foreach (var item in element.EnumerateObject())
            {
                var name = item.Name;

                foreach (var version in item.Value.EnumerateArray().Select(elem => elem.GetString()!))
                {
                    var reference = new Package(name, SemVersion.Parse(version, SemVersionStyles.Any));

                    references.Add(reference);
                }
            }

            return new Catalog(references);
        }

        public static byte[] Download()
        {
            var requestUri = "https://package.elm-lang.org/all-packages";

            Console.Write($"download {requestUri} ...");

            using (var request = new HttpClient())
            {
                var response = request.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead).Result;

                var bytes = response.Content.ReadAsByteArrayAsync().Result;

                Console.WriteLine();

                return bytes;
            }

        }


        public int Count => references.Count;
        public Package this[int index] => references[index];
        public IEnumerator<Package> GetEnumerator() => references.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
