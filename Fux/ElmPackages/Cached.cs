﻿using System.Net.Http;
using System.Text.Json;

namespace Fux.ElmPackages
{
    internal abstract class Cached
    {
        protected Cached(ElmPackage reference, string name)
        {
            Reference = reference;
            Name = name;
        }

        public ElmPackage Reference { get; }
        public string Name { get; }

        protected static bool IsCached(ElmPackage reference, string file) => IO.File.Exists(CachePath(reference, file));

        protected static string CachePath(ElmPackage reference, string file)
        {
            var path = ElmCache.FilePath(reference.ToString(), file);

            IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(path)!);

            return path;
        }

        protected static JsonDocument Load(ElmPackage reference, string file)
        {
            var bytes = IO.File.ReadAllBytes(CachePath(reference, file));

            var json = Encoding.UTF8.GetString(bytes);

            return JsonDocument.Parse(json);
        }

        protected static byte[] Download(ElmPackage reference, string file)
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
