using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fux.ElmPackages
{
    internal class Elm
    {
        private const string File = "elm.json";

        public static Elm From(Package package, byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);

            var document = JsonDocument.Parse(json);

            var element = document.RootElement;

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
    }
}
