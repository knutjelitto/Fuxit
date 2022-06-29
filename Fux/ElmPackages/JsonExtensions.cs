using System.Text;
using System.Text.Json;

namespace Fux.ElmPackages
{
    public static class JsonExtensions
    {
        public static JsonElement GetRootElement(this byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);

            var doc = JsonDocument.Parse(json);

            var element = doc.RootElement;

            return element;
        }
    }
}
