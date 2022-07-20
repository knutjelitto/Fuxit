namespace Fux.Input.Ast
{
    public sealed class RecordPattern : Expr.ExprImpl
    {
        public RecordPattern(IEnumerable<FieldPattern> fields)
        {
            Fields = fields.ToList();
        }
        
        public List<FieldPattern> Fields { get; }

        public override string ToString()
        {
            var joined = string.Join(", ", Fields);
            return $"{Lex.LeftCurlyBracket} {joined} {Lex.RCurlyBracket}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Lex.LeftCurlyBracket} ");
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
            writer.WriteLine($"{Lex.RCurlyBracket}");
        }
    }
}
