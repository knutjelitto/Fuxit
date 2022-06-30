using Fux.Building;

namespace Fux.Input.Ast
{
    public sealed class Case : Expr.ExprImpl
    {
        public Case(Expr pattern, Expr expression)
        {
            Pattern = pattern;
            Expression = expression;

            Collector.Instance.MatchPattern.Add(Pattern);
        }

        public Expr Pattern { get; }
        public Expr Expression { get; }

        public LetScope Scope { get; } = new();

        public override string ToString()
        {
            return $"{Pattern} {Lex.Arrow} {Expression}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Pattern} {Lex.Arrow} ");
            Expression.PP(writer);
            writer.EndLine();
        }
    }
}
