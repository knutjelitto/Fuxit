using System.Text.Json;

namespace Fux.FuxPackages
{
    public class FuxJson : JsonBase
    {
        public string Type { get; protected set; } = string.Empty;

        public static FuxJson From(Package package, byte[] bytes)
        {
            var rootElement = GetRootElement(bytes);

            Assert(rootElement.ValueKind == JsonValueKind.Object);

            foreach (var property in rootElement.EnumerateObject())
            {
                if (property.Name == "type")
                {
                    var value = property.Value.GetString();

                    if (property.Value.GetString() == "package")
                    {
                        return new FuxPackageJson(package, rootElement);
                    }
                    else if (property.Value.GetString() == "application")
                    {
                        return FuxApplicationJson.Decode(rootElement);
                    }
                    throw new InvalidOperationException($"can not decode fux file of type \"{value}\"");
                }
            }

            throw new InvalidOperationException($"can not decode fux file");
        }
    }
}
