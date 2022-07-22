namespace Fux.Building.Typing
{
    public static class NamingExtensions
    {
        public static W.Expr.Variable FullName(this A.NamedDecl named)
        {
            Assert(named.InModule != null);

            var name = $"{named.InModule.Name}.{named.Name}";
            var variable = new W.Expr.Variable(name);

            Assert(name != "Main.x");

            return variable;
        }

        public static string FullName(this A.Type.Custom named)
        {
            Assert(named.Declaration != null);

            if (named.Declaration is A.NamedDecl namedDecl && namedDecl.InModule != null)
            {
                var name = $"{namedDecl.InModule.Name}.{namedDecl.Name}";

                Assert(!name.StartsWith("Set.Dict."));

                return name;
            }
            else
            {
                Assert(false);
                var name = $"{named.InModule.Name}.{named.Name}";

                Assert(!name.StartsWith("Set.Dict."));

                return name;
            }
        }
    }
}
