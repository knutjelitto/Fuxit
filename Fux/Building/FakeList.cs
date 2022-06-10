using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Building
{
    internal static class FakeList
    {
        const string list = "List";

        public static TypeDecl MakeType(Module module)
        {
            Assert(module.Name == list);

            var listId = Identifier.Artificial(module, list);
            var paraId = Identifier.Artificial(module, "a");
            var para = new Type.Parameter(paraId);
            var args = new TypeArguments(para);
            var ctor = new Type.Constructor(listId, args);
            var ctors = new Constructors(ctor);
            var parameters = new TypeParameters(paraId);
            var type = new TypeDecl(listId, parameters, ctors);

            return type;
        }

        public static Exposing MakeExposing(Module module)
        {
            Assert(module.Name == list);

            var listId = Identifier.Artificial(module, list);

            return new ExposingSome(new ExposedType(listId, true));
        }
    }
}
