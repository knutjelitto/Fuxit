namespace Fux.Input.Ast
{
    public sealed class ModuleAst : Expr.ExprImpl
    {
        public ModuleAst(ModuleDecl header, IEnumerable<Decl> declarations)
        {
            Header = header;
            Declarations = declarations.ToArray();
        }

        public ModuleDecl Header { get; }
        public IReadOnlyList<Decl> Declarations { get; }

        public IEnumerable<ImportDecl> Imports => Declarations.OfType<ImportDecl>();

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
