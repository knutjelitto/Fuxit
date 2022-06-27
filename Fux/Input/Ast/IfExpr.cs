namespace Fux.Input.Ast
{
    internal class IfExpr : Expr
    {
        public IfExpr(Expr condition, Expr ifTrue, Expr ifFalse)
        {
            Condition = condition;
            IfTrue = ifTrue;
            IfFalse = ifFalse;
        }

        public Expr Condition { get; }
        public Expr IfTrue { get; }
        public Expr IfFalse { get; }

        public override string ToString()
        {
            return $"{Lex.KwIf} {Condition} {Lex.KwThen} {IfTrue} {Lex.KwElse} {IfFalse}";
        }

        public override void PP(Writer writer)
        {
            var line = ToString();

            if (ToString().Length > WhatIsLong)
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
                writer.WriteLine($"{Lex.KwIf}");
                writer.Indent(() =>
                {
                    Condition.PP(writer);
                });
                writer.EndLine();
                writer.WriteLine($"{Lex.KwThen}");
                writer.Indent(() =>
                {
                    IfTrue.PP(writer);
                });
                writer.EndLine();
                writer.WriteLine($"{Lex.KwElse}");
                writer.Indent(() =>
                {
                    IfFalse.PP(writer);
                });
                writer.EndLine();
            }
        }
    }
}
