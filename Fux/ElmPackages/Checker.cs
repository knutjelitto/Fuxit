using System.Text;
using System.Text.Json;

#pragma warning disable CA1822 // Mark members as static

namespace Fux.ElmPackages
{
    internal class Checker
    {
        public void DownloadDocsJson(ElmPackage reference)
        {
            var requestUri = $"https://package.elm-lang.org/packages/{reference}/docs.json";

            using (var request = new HttpClient())
            {
                var response = request.GetAsync(requestUri, HttpCompletionOption.ResponseContentRead).Result;

                var bytes = response.Content.ReadAsByteArrayAsync().Result;

                var json = Encoding.UTF8.GetString(bytes);

                var content = JsonDocument.Parse(json).RootElement;
            }
        }
    }
}
