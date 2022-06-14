namespace Fux.ElmPackages
{
    internal class Archive
    {
        public static readonly string Filename = "archive.zip";

        public Archive(Endpoint endpoint)
        {
            Endpoint = endpoint;
        }

        public Endpoint Endpoint { get; }

        public static string Get(Endpoint endpoint)
        {
            byte[] bytes;

            var filePath = Path.Combine(ElmCache.FilePath(endpoint.Reference.ToString(), Filename));

            if (!File.Exists(filePath))
            {
                bytes = Download(endpoint);

                File.WriteAllBytes(filePath, bytes);
            }

            return filePath;
        }

        public static byte[] Download(Endpoint endpoint)
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
