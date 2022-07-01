#pragma warning disable IDE0017 // Simplify object initialization

namespace Fux.Building
{
    public static class FakeList
    {
        public static A.Decl.Custom MakeType(Module module)
        {
            Assert(module.Name == Lex.Primitive.List);

            var listId = A.Identifier.Artificial(module, Lex.Primitive.List);
            listId.InModule = module;
            var paraId = A.Identifier.Artificial(module, "a");
            paraId.InModule = module;
            var para = new A.Decl.TypeParameter(paraId);
            para.InModule = module;
            var paras = new A.TypeParameterList(para);
            paras.InModule = module;
            var parameters = new A.TypeParameterList(new A.Decl.TypeParameter(paraId));
            parameters.InModule = module;

            var arg = new A.Type.Parameter(paraId);
            arg.InModule = module;
            var args = new A.TypeArgumentList(arg);
            args.InModule = module;
            var ctor = new A.Decl.Constructor(listId, args);
            ctor.InModule = module;
            var ctors = new A.CtorList(ctor);
            ctors.InModule = module;

            var type = new A.Decl.Custom(listId, parameters, ctors);
            type.InModule = module;

            return type;
        }

        public static A.Exposing MakeExposing(Module module)
        {
            Assert(module.Name == Lex.Primitive.List);

            var listId = A.Identifier.Artificial(module, Lex.Primitive.List);

            return new A.ExposingSome(new A.Exposed.Type(listId, true));
        }
    }
}
