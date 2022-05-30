using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fux.ElmPackages
{
    internal class Docs
    {
        public static Docs Get(Package reference)
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
