using System.Net.Http;
using System.Text.Json;

namespace Fux.ElmPackages
{
    public sealed class Endpoint
    {
        public static readonly string Filename = "endpoint.json";

        private Endpoint(ElmPackage reference, string url, string hash)
        {
            Reference = reference;
            Url = url;
            Hash = hash;
        }

        public ElmPackage Reference { get; }
        public string Url { get; }
        public string Hash { get; }

        public static Endpoint Get(ElmPackage reference)
        {
            byte[] bytes;

            var filePath = IO.Path.Combine(ElmCache.FilePath(reference.ToString(), Filename));

            if (!IO.File.Exists(filePath))
            {
                bytes = Download(reference);

                IO.File.WriteAllBytes(filePath, bytes);
            }
            else
            {
                bytes = IO.File.ReadAllBytes(filePath);
            }

            return Decode(reference, bytes);
        }

        public static Endpoint Decode(ElmPackage reference, byte[] bytes)
        {
            // {"url":"https://github.com/elm/browser/zipball/1.0.2/","hash":"3e42bad1272885793ce153613e446f8425e29e32"}

            try
            {
                var content = bytes.GetRootElement();

                Assert(content.ValueKind == JsonValueKind.Object);

                var properties = content.EnumerateObject().ToList();

                Assert(properties.Count == 2);
                Assert(properties[0].Name == "url" && properties[0].Value.ValueKind == JsonValueKind.String);
                Assert(properties[1].Name == "hash" && properties[1].Value.ValueKind == JsonValueKind.String);

                return new Endpoint(reference, properties[0].Value.GetString()!, properties[1].Value.GetString()!);
            }
            catch
            {
                // invalid json

                var url = $"https://github.com/{reference.Name}/zipball/{reference.Version}/";

                return new Endpoint(reference, url, "");

                throw;
            }

        }

        public static byte[] Download(ElmPackage reference)
        {
            var requestUri = $"https://package.elm-lang.org/packages/{reference}/endpoint.json";

            Terminal.Write($"download {requestUri} ...");

            using var request = new HttpClient();

            var response = request.GetAsync(requestUri, HttpCompletionOption.ResponseContentRead).Result;

            var bytes = response.Content.ReadAsByteArrayAsync().Result;

            Terminal.WriteLine();

            return bytes;
        }

    }
}
