namespace Fux.Building.Typing
{
    public static class NamingExtensions
    {
        public static W.Expr.Variable FullName(this A.NamedDecl named)
        {
            Assert(named.InModule != null);

            var name = $"{named.InModule.Name}.{named.Name}";
            var variable = new W.Expr.Variable(name);

            return variable;
        }

        public static string FullName(this A.Type.Custom named)
        {
            Assert(named.InModule != null);

            var name = $"{named.InModule.Name}.{named.Name}";

            Assert(!name.StartsWith("Set.Dict."));

            return name;
        }

        public static string FullName(this A.Type.CustomX named)
        {
            Assert(named.InModule != null);

            var name = $"{named.InModule.Name}.{named.Name}";

            Assert(!name.StartsWith("Set.Dict."));

            return name;
        }
    }
}
