#pragma warning disable IDE0017 // Simplify object initialization

namespace Fux.Building
{
    public static class FakeList
    {
        public static A.TypeDecl MakeType(Module module)
        {
            Assert(module.Name == Lex.Primitive.List);

            var listId = A.Identifier.Artificial(module, Lex.Primitive.List);
            listId.Module = module;
            var paraId = A.Identifier.Artificial(module, "a");
            paraId.Module = module;
            var para = new A.TypeParameter(paraId);
            para.Module = module;
            var paras = new A.TypeParameterList(para);
            paras.Module = module;
            var parameters = new A.TypeParameterList(new A.TypeParameter(paraId));
            parameters.Module = module;

            var arg = new A.Type.Parameter(paraId);
            arg.Module = module;
            var args = new A.TypeArgumentList(arg);
            args.Module = module;
            var ctor = new A.Constructor(listId, args);
            ctor.Module = module;
            var ctors = new A.ConstructorList(ctor);
            ctors.Module = module;

            var type = new A.TypeDecl(listId, parameters, ctors);
            type.Module = module;

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
