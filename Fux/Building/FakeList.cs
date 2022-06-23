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

        public static A.UnionDecl MakeType(Module module)
        {
            Assert(module.Name == list);

            var listId = A.Identifier.Artificial(module, list);
            var paraId = A.Identifier.Artificial(module, "a");
            var para = new A.Type.Parameter(paraId);
            var args = new A.TypeArguments(para);
            var ctor = new A.Type.Constructor(listId, args);
            var ctors = new A.Constructors(ctor);
            var parameters = new A.TypeParameters(new A.Type.Parameter(paraId));
            var type = new A.UnionDecl(listId, parameters, ctors);

            return type;
        }

        public static A.Exposing MakeExposing(Module module)
        {
            Assert(module.Name == list);

            var listId = A.Identifier.Artificial(module, list);

            return new A.ExposingSome(new A.ExposedType(listId, true));
        }
    }
}
