#pragma warning disable IDE1006 // Naming Styles

namespace Fux.Building.AlgorithmW
{
    public static class TesterHelper
    {
        public static Expr.Let let(string name, Expr e1, Expr e2)
        {
            return new Expr.Let(name, e1, e2);
        }

        public static Expr.Iff iff(Expr cond, Expr then, Expr @else)
        {
            return new Expr.Iff(cond, then, @else);
        }

        public static Expr.Abstraction abs(string var, Expr e)
        {
            return new Expr.Abstraction(var, e);
        }

        public static Expr.Application app(Expr e1, Expr e2)
        {
            return new Expr.Application(e1, e2);
        }

        public static Expr.Application app(Expr e1, Expr e2, Expr e3)
        {
            return app(app(e1, e2), e3);
        }

        public static Expr.Literal.Integer integer(int value)
        {
            return new Expr.Literal.Integer(value);
        }

        public static Expr.Literal.Float floating(double value)
        {
            return new Expr.Literal.Float(value);
        }

        public static Expr.Literal.Bool lit(bool value)
        {
            return new Expr.Literal.Bool(value);
        }

        public static Expr.Literal.String lit(string value)
        {
            return new Expr.Literal.String(value);
        }

        public static Expr.Variable var(string name)
        {
            return new Expr.Variable(name);
        }
    }
}
