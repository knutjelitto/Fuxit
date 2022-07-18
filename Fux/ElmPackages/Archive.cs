using System.Net.Http;

namespace Fux.ElmPackages
{
    public sealed class Archive
    {
        public static readonly string Filename = "archive.zip";

        public Archive(EndpointJson endpoint)
        {
            Endpoint = endpoint;
        }

        public EndpointJson Endpoint { get; }

        public static string Get(EndpointJson endpoint)
        {
            byte[] bytes;

            var filePath = IO.Path.Combine(Cache.FilePath(endpoint.Reference.ToString(), Filename));

            if (!IO.File.Exists(filePath))
            {
                bytes = Download(endpoint);

                IO.File.WriteAllBytes(filePath, bytes);
            }

            return filePath;
        }

        public static byte[] Download(EndpointJson endpoint)
        {
            var requestUri = endpoint.Url;

            Terminal.Write($"download {requestUri} ...");

            using (var request = new HttpClient())
            {
                var response = request.GetAsync(requestUri, HttpCompletionOption.ResponseContentRead).Result;

                var bytes = response.Content.ReadAsByteArrayAsync().Result;

                Terminal.WriteLine();

                return bytes;
            }
        }

    }
}
