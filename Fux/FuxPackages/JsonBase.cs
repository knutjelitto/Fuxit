using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fux.FuxPackages
{
    public class JsonBase
    {
        protected static JsonElement GetRootElement(byte[] bytes)
        {
            var json = Encoding.UTF8.GetString(bytes);

            var doc = JsonDocument.Parse(json);

            var element = doc.RootElement;

            return element;
        }
    }
}
