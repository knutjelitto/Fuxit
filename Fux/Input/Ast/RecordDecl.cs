namespace Fux.Input.Ast
{
    internal class RecordDecl : Type
    {
        public RecordDecl(Type? baseRecord, IEnumerable<FieldDefine> fields)
        {
            BaseRecord = baseRecord;
            Fields = fields.ToArray();
        }

        public Type? BaseRecord { get; }

        public IReadOnlyList<FieldDefine> Fields { get; }

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
