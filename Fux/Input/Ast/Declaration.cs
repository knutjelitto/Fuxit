namespace Fux.Input.Ast
{
    internal abstract class Declaration : Expression
    {
        protected Declaration(Identifier name)
        {
            Name = name;
        }

        public Identifier Name { get; }
    }
}
