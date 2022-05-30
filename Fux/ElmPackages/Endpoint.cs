using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fux.ElmPackages
{
    internal class Endpoint
    {
        public static readonly string Filename = "endpoint.json";

        private Endpoint(Package reference, string url, string hash)
        {
            Reference = reference;
            Url = url;
            Hash = hash;
        }

        public Package Reference { get; }
        public string Url { get; }
        public string Hash { get; }

        public static Endpoint Get(Package reference)
        {
            byte[] bytes;

            var filePath = Path.Combine(ElmCache.Instance.FilePath(reference.ToString(), Filename));

            if (!File.Exists(filePath))
            {
                bytes = Download(reference);

                File.WriteAllBytes(filePath, bytes);
            }
            else
            {
                bytes = File.ReadAllBytes(filePath);
            }

            return Decode(reference, bytes);
        }

        public static Endpoint Decode(Package reference, byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);

            var content = JsonDocument.Parse(json).RootElement;

            var properties = content.EnumerateObject().ToList();

            Assert(properties.Count == 2);
            Assert(properties[0].Name == "url");
            Assert(properties[1].Name == "hash");

            return new Endpoint(reference, properties[0].Value.GetString()!, properties[1].Value.GetString()!);
        }

        public static byte[] Download(Package reference)
        {
            var requestUri = $"https://package.elm-lang.org/packages/{reference}/endpoint.json";

            Console.Write($"download {requestUri} ...");

            using (var request = new HttpClient())
            {
                var response = request.GetAsync(requestUri, HttpCompletionOption.ResponseContentRead).Result;

                var bytes = response.Content.ReadAsByteArrayAsync().Result;

                Console.WriteLine();

                return bytes;
            }
        }

    }
}
