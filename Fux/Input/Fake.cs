namespace Fux.Input
{
    internal static class Fake
    {
        public static A.VarDecl Negate(ISource source)
        {
            var basics = A.Identifier.Artificial(source, "Elm.Kernel.Basics");
            var name = A.Identifier.Artificial(source, "negate");
            var native = new A.NativeDecl(basics, name);
            return new A.VarDecl(name, new A.Parameters(), native);
        }

        public static A.NativeDecl NativeNegate(ISource source)
        {
            var basics = A.Identifier.Artificial(source, "Elm.Kernel.Basics");
            var name = A.Identifier.Artificial(source, "negate");
            return new A.NativeDecl(basics, name);
        }
    }
}
