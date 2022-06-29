using Fux.Building;

namespace Fux.Input.Ast
{
    public sealed class LambdaExpr : Expr.ExprImpl
    {
        public LambdaExpr(Pattern parameters, Expr expr)
        {
            Parameters = parameters;
            Expression = expr;
        }

        public Pattern Parameters { get; }
        public Expr Expression { get; }

        public LetScope Scope { get; } = new();

        public override string ToString()
        {
            return Protected($"{Lex.Lambda}{Parameters} {Lex.Arrow} {Expression}");
        }

        public override void PP(Writer writer)
        {
            writer.Write(ToString());
        }
    }
}
