using System.Text.Json;

namespace Fux.ElmPackages
{
    public sealed class Docs
    {
        public static Docs Get(ElmPackage reference)
        {
            throw new NotImplementedException();
        }

        public static Docs Decode(JsonElement element)
        {
            Assert(element.ValueKind == JsonValueKind.Array);

            foreach (var item in element.EnumerateArray())
            {

            }

            return new Docs();
        }
    }
}
