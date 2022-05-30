using Fux.Input;

namespace Fux.Ast
{
    internal class Import : Expression
    {
        public Import(Expression path, Expression? alias, Expression? exposed)
        {
            Path = path;
            Alias = alias;
            Exposed = exposed;
        }

        public Expression Path { get; }
        public Expression? Alias { get; }
        public Expression? Exposed { get; }

        public override bool IsAtomic => false;

        public override string ToString()
        {
            var alias = Alias == null ? "" : $" as {Alias}";
            var exposed = Exposed == null ? "" : $" {Lex.Weak.Exposing} {Exposed}";

            return $"import {Path}{alias}{exposed}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"import {Path}");
            if (Alias != null)
            {
                writer.Write($" alias {Alias}");
            }
            if (Exposed != null)
            {
                writer.Write($" {Lex.Weak.Exposing} {Exposed}");
            }
            writer.WriteLine();
        }
    }
}
