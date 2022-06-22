using A = Fux.Input.Ast;

namespace Fux.Input
{
    internal static class Fake
    {
        public static VarDecl Negate(ISource source)
        {
            var basics = A.Identifier.Artificial(source, "Elm.Kernel.Basics");
            var name = A.Identifier.Artificial(source, "negate");
            var native = new NativeDecl(basics, name);
            return new VarDecl(name, new Parameters(), native);
        }

        public static NativeDecl NativeNegate(ISource source)
        {
            var basics = A.Identifier.Artificial(source, "Elm.Kernel.Basics");
            var name = A.Identifier.Artificial(source, "negate");
            return new NativeDecl(basics, name);
        }
    }
}
