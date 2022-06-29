using Fux.Building;

namespace Fux.Input
{
    public static class Fake
    {
        public static A.Expr NativeNegate(Module module, ISource source)
        {
            var basics = A.Identifier.Artificial(source, "Elm.Kernel.Basics");
            basics.Module = module;

            var name = A.Identifier.Artificial(source, "negate");
            name.Module = module;

            var native = new A.NativeDecl(basics, name);
            native.Module = module;

            var reference = new A.Ref.Native(native);
            reference.Module = module;

            return reference;
        }
    }
}
