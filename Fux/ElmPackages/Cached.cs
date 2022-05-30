using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fux.ElmPackages
{
    internal abstract class Cached
    {
        protected Cached(Package reference, string name)
        {
            Reference = reference;
            Name = name;
        }

        public Package Reference { get; }
        public string Name { get; }

        protected static bool IsCached(Package reference, string file) => File.Exists(CachePath(reference, file));

        protected static string CachePath(Package reference, string file)
        {
            var path = ElmCache.FilePath(reference.ToString(), file);

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);

            return path;
        }

        protected static JsonDocument Load(Package reference, string file)
        {
            var bytes = File.ReadAllBytes(CachePath(reference, file));

            var json = Encoding.UTF8.GetString(bytes);

            return JsonDocument.Parse(json);
        }

        protected static byte[] Download(Package reference, string file)
        {
            var requestUri = $"https://package.elm-lang.org/packages/{reference}/{file}";

            using (var request = new HttpClient())
            {
                var response = request.GetAsync(requestUri, HttpCompletionOption.ResponseContentRead).Result;

                var bytes = response.Content.ReadAsByteArrayAsync().Result;

                return bytes;
            }
        }
    }
}
