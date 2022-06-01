namespace Fux.Ast
{
    internal class AstModule : Expression
    {
        public AstModule(Header header, IEnumerable<Expression> expressions)
        {
            Header = header;
            Expressions = expressions.ToArray();
        }

        public Header Header { get; }
        public IReadOnlyList<Expression> Expressions { get; }
        public override bool IsAtomic => false;

        public IEnumerable<Import> Imports => Expressions.OfType<Import>();

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
                if (writer.LineRunning)
                {
                    writer.WriteLine();
                }
                Assert(!writer.LineRunning);
            }
            writer.WriteLine();
        }
    }
}
