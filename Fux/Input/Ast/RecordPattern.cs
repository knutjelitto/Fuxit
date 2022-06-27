namespace Fux.Input.Ast
{
    internal class RecordPattern : Expr
    {
        public RecordPattern(IEnumerable<FieldPattern> fields)
        {
            Fields = fields.ToArray();
        }
        
        public IReadOnlyList<FieldPattern> Fields { get; }

        public override string ToString()
        {
            var joined = string.Join(", ", Fields);
            return $"{Lex.LBrace} {joined} {Lex.RBrace}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Lex.LBrace} ");
            var more = false;
            foreach (var field in Fields)
            {
                if (more)
                {
                    writer.WriteLine();
                    writer.Write($"{Lex.Comma} ");
                }
                more = true;
                field.PP(writer);
            }
            if (writer.LinePending)
            {
                writer.WriteLine();
            }
            writer.WriteLine($"{Lex.RBrace}");
        }
    }
}
