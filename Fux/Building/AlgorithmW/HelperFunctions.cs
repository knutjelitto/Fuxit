#pragma warning disable IDE1006 // Naming Styles

namespace Fux.Building.AlgorithmW
{
    public static class HelperFunctions
    {
        public static LetExpression let(string name, Expression e1, Expression e2)
        {
            return new LetExpression(name, e1, e2);
        }

        public static IffExpression iff(Expression cond, Expression then, Expression @else)
        {
            return new IffExpression(cond, then, @else);
        }

        public static AbstractionExpression abs(string var, Expression e)
        {
            return new AbstractionExpression(var, e);
        }

        public static ApplicationExpression app(Expression e1, Expression e2)
        {
            return new ApplicationExpression(e1, e2);
        }

        public static ApplicationExpression app(Expression e1, Expression e2, Expression e3)
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
