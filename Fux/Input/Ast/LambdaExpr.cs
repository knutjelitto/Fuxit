using Fux.Building;

namespace Fux.Input.Ast
{
    internal class LambdaExpr : Expression
    {
        public LambdaExpr(Pattern.List parameters, Expression expr)
        {
            Parameters = parameters;
            Expression = expr;
        }

        public Pattern.List Parameters { get; }
        public Expression Expression { get; }

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
