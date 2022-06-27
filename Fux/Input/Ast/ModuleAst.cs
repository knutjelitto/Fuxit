namespace Fux.Input.Ast
{
    internal class ModuleAst : Expr
    {
        public ModuleAst(ModuleDecl header, IEnumerable<Expr> expressions)
        {
            Header = header;
            Expressions = expressions.ToArray();
        }

        public ModuleDecl Header { get; }
        public IReadOnlyList<Expr> Expressions { get; }

        public IEnumerable<ImportDecl> Imports => Expressions.OfType<ImportDecl>();
        public IEnumerable<Declaration> Declarations => Expressions.OfType<Declaration>();
        public IEnumerable<Expr> Rest => Expressions.Where(e => e is not Declaration);

        public override string ToString()
        {
            return $"{Header}";
        }

        public override void PP(Writer writer)
        {
            Header.PP(writer);
            foreach (var expression in Expressions)
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
