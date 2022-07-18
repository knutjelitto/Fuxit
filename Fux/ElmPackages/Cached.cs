using System.Net.Http;
using System.Text.Json;

namespace Fux.ElmPackages
{
    public abstract class Cached
    {
        protected Cached(Package reference, string name)
        {
            Reference = reference;
            Name = name;
        }

        public Package Reference { get; }
        public string Name { get; }

        protected static bool IsCached(Package reference, string file) => IO.File.Exists(CachePath(reference, file));

        protected static string CachePath(Package reference, string file)
        {
            var path = Cache.FilePath(reference.ToString(), file);

            IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(path)!);

            return path;
        }

        protected static JsonDocument Load(Package reference, string file)
        {
            var bytes = IO.File.ReadAllBytes(CachePath(reference, file));

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
