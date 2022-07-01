namespace Fux.Input.Ast
{
    public sealed class ModuleAst : Expr.ExprImpl
    {
        public ModuleAst(Decl.Module header, IEnumerable<Decl> declarations)
        {
            Header = header;
            Declarations = declarations.ToArray();
        }

        public Decl.Module Header { get; }
        public IReadOnlyList<Decl> Declarations { get; }

        public IEnumerable<Decl.Import> Imports => Declarations.OfType<Decl.Import>();

        public override string ToString()
        {
            return $"{Header}";
        }

        public override void PP(Writer writer)
        {
            Header.PP(writer);
            foreach (var expression in Declarations)
            {
                writer.WriteLine();
                expression.PP(writer);
                if (writer.LinePending)
                {
                    writer.WriteLine();
                }
                Assert(!writer.LinePending);
            }
            writer.WriteLine();
        }
    }
}
