namespace Fux.Input.Ast
{
    internal class RecordExpr : Expr
    {
        public RecordExpr(Identifier? baseRecord, IEnumerable<FieldAssign> fields)
        {
            Fields = fields.ToArray();
            BaseRecord = baseRecord;
        }

        public Identifier? BaseRecord { get; }

        public IReadOnlyList<FieldAssign> Fields { get; }

        public override string ToString()
        {
            var joined = string.Join(", ", Fields);
            var baser = BaseRecord == null ? "" : $" {BaseRecord}, ";
            return $"{Lex.LBrace} {baser}{joined} {Lex.RBrace}";
        }

        public override void PP(Writer writer)
        {
            var line = ToString();

            if (line.Length > WhatIsLong)
            {
                if (writer.LinePending)
                {
                    writer.WriteLine();
                    writer.Indent(Write);
                }
                else
                {
                    Write();
                }
            }
            else
            {
                writer.Write(line);
            }

            void Write()
            {
                writer.Write($"{Lex.LBrace} ");
                var more = false;
                if (BaseRecord != null)
                {
                    writer.Write($"{BaseRecord}");
                    more = true;
                }
                foreach (var expression in Fields)
                {
                    if (more)
                    {
                        writer.WriteLine();
                        writer.Write($"{Lex.Comma} ");
                    }
                    more = true;
                    expression.PP(writer);
                }
                writer.EndLine();
                writer.Write($"{Lex.RBrace}");
            }
        }
    }
}
