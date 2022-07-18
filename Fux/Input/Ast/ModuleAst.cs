namespace Fux.Input.Ast
{
    public sealed class ModuleAst : Expr.ExprImpl
    {
        public ModuleAst(Decl.Header header, IEnumerable<Decl> declarations)
        {
            Header = header;
            Declarations = declarations.ToArray();
        }

        public Decl.Header Header { get; }
        public IReadOnlyList<Decl> Declarations { get; }

        public IEnumerable<Decl.Import> ImportDeclarations => Declarations.OfType<Decl.Import>();
        public IEnumerable<Decl> TypeDeclarations => Declarations.Where(d => d is Decl.Custom || d is Decl.Alias);
        public IEnumerable<Decl.Var> VarDeclarations => Declarations.OfType<Decl.Var>();

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
