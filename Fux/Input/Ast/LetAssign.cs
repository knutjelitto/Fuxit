using Fux.Building;

namespace Fux.Input.Ast
{
    public sealed class LetAssign : Decl.DeclImpl
    {
        public LetAssign(Pattern pattern, Expr expression)
        {
            Assert(pattern is not Pattern.LowerId);

            Pattern = pattern;
            Expression = expression;

            Collector.Instance.LetPattern.Add(pattern);
        }

        public Pattern Pattern { get; }
        public Expr Expression { get; }
        public LetScope Scope { get; } = new();

        public override string ToString()
        {
            return $"{Pattern} {Lex.Assign} {Expression}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Pattern} {Lex.Assign} ");
            Expression.PP(writer);
            writer.EndLine();
        }
    }
}
