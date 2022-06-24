using Fux.Building;

namespace Fux.Input.Ast
{
    internal class LetAssign : Expression
    {
        public LetAssign(Pattern pattern, Expression expression)
        {
            Assert(pattern is not Pattern.LowerId);

            Pattern = pattern;
            Expression = expression;

            Collector.Instance.VarPattern.Add(pattern);
        }

        public Pattern Pattern { get; }
        public Expression Expression { get; }
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
