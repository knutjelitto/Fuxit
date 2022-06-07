using Fux.Building;

namespace Fux.Input.Ast
{
    internal class VarDecl : Declaration
    {
        public VarDecl(Identifier name, Parameters parameters, Expression expression)
            : base(name)
        {
            Parameters = parameters;
            Expression = expression;
        }

        public Parameters Parameters { get; }
        public Expression Expression { get; }

        public TypeHint? Hint { get; set; }
        public LetScope Scope { get; } = new LetScope();

        public override string ToString()
        {
            var parameters = Parameters.Count == 0 ? "" : $" {string.Join(' ', Parameters)}";
            return $"{Name}{parameters} {Lex.Assign} {Expression}";
        }

        public override void PP(Writer writer)
        {
            var parameters = Parameters.Count == 0 ? "" : $" {string.Join(' ', Parameters)}";
            writer.Write($"{Name}{parameters} {Lex.Assign}");
            if (writer.Indentation == 0)
            {
                writer.WriteLine();
                writer.Indent(() =>
                {
                    Expression.PP(writer);
                });
            }
            else
            {
                writer.Write(" ");
                Expression.PP(writer);
            }
        }
    }
}
