using System.Net.Http;
using System.Text.Json;

namespace Fux.ElmPackages
{
    public class Elm
    {
        private const string File = "elm.json";

        public string Type { get; protected set; } = string.Empty;
        public Dependency ElmVersion { get; protected set; } = new("elm-version", new(new(0)));

        public static Elm From(ElmPackage package, byte[] bytes)
        {
            var element = bytes.GetRootElement();

            Assert(element.ValueKind == JsonValueKind.Object);

            foreach (var property in element.EnumerateObject())
            {
                if (property.Name == "type")
                {
                    var value = property.Value.GetString();

                    if (property.Value.GetString() == "package")
                    {
                        return new ElmPak(package, element);
                    }
                    else if (property.Value.GetString() == "application")
                    {
                        return ElmApp.Decode(element);
                    }
                    throw new InvalidOperationException($"can not decode elm file of type \"{value}\"");
                }
            }

            throw new InvalidOperationException($"can not decode elm file");
        }

        public static byte[] Download(ElmPackage package)
        {
            var requestUri = $"https://package.elm-lang.org/packages/{package}/elm.json";

            using var request = new HttpClient();

            var response = request.GetAsync(requestUri, HttpCompletionOption.ResponseContentRead).Result;

            var bytes = response.Content.ReadAsByteArrayAsync().Result;

            return bytes;
        }
    }
}
