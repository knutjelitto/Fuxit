using W = Fux.Building.AlgorithmW;

namespace Fux.Building.Typing
{
    public static class BuildHelper
    {
        public static W.Expr.Variable AsVariable(this A.NamedDecl decl)
        {
            Assert(decl.InModule != null);

            var name = $"{decl.InModule.Name}.{decl.Name}";
            var variable = new W.Expr.Variable(name);

            return variable;
        }
    }
}
