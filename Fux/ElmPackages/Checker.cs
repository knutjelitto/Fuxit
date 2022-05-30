using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

using static System.Net.WebRequestMethods;

#pragma warning disable CA1822 // Mark members as static

namespace Fux.ElmPackages
{
    internal class Checker
    {
        public void DownloadDocsJson(Package reference)
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

        private string GetDotFux()
        {
            var profile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var dotFux = Path.Combine(profile, ".fux");

            Directory.CreateDirectory(dotFux);

            return dotFux.Replace('\\', '/');
        }

        private string GetDotElm()
        {
            var dotElm = Path.Combine(GetDotFux(), "elm");

            Directory.CreateDirectory(dotElm);

            return dotElm.Replace('\\', '/');
        }

        private string GetDotElmCache()
        {
            var dotCache = Path.Combine(GetDotElm(), "cache");

            Directory.CreateDirectory(dotCache);

            return dotCache.Replace('\\', '/');
        }
    }
}
