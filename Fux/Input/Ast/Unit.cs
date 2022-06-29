namespace Fux.Input.Ast
{
    public sealed class Unit : Expr.ExprImpl
    {
        public override string ToString()
        {
            return "()";
        }

        public override void PP(Writer writer)
        {
            writer.Write("()");
        }
    }
}
