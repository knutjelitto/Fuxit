#pragma warning disable IDE1006 // Naming Styles

namespace Fux.Building.AlgorithmW
{
    internal static class TesterHelper
    {
        public static LetExpression let(string name, Expr e1, Expr e2)
        {
            return new LetExpression(name, e1, e2);
        }

        public static IffExpression iff(Expr cond, Expr then, Expr @else)
        {
            return new IffExpression(cond, then, @else);
        }

        public static AbstractionExpression abs(string var, Expr e)
        {
            return new AbstractionExpression(var, e);
        }

        public static ApplicationExpression app(Expr e1, Expr e2)
        {
            return new ApplicationExpression(e1, e2);
        }

        public static ApplicationExpression app(Expr e1, Expr e2, Expr e3)
        {
            return app(app(e1, e2), e3);
        }

        public static IntegerLiteral integer(int value)
        {
            return new IntegerLiteral(value);
        }

        public static FloatLiteral floating(double value)
        {
            return new FloatLiteral(value);
        }

        public static BoolLiteral lit(bool value)
        {
            return new BoolLiteral(value);
        }

        public static StringLiteral lit(string value)
        {
            return new StringLiteral(value);
        }

        public static Variable var(string name)
        {
            return new Variable(name);
        }
    }
}
