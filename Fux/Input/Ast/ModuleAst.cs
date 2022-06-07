namespace Fux.Input.Ast
{
    internal class ModuleAst : Expression
    {
        public ModuleAst(ModuleDecl header, IEnumerable<Expression> expressions)
        {
            Header = header;
            Expressions = expressions.ToArray();
        }

        public ModuleDecl Header { get; }
        public IReadOnlyList<Expression> Expressions { get; }

        public IEnumerable<ImportDecl> Imports => Expressions.OfType<ImportDecl>();
        public IEnumerable<Declaration> Declarations => Expressions.OfType<Declaration>();

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
