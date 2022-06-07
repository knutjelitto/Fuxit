namespace Fux.Input.Ast
{
    internal class InfixDecl : Declaration
    {
        public InfixDecl(InfixAssoc assoc, InfixPower power, Identifier op, Identifier expression)
            : base(op)
        {
            Assoc = assoc;
            Power = power;
            Expression = expression;
        }

        public InfixAssoc Assoc { get; }
        public InfixPower Power { get; }
        public Identifier Expression { get; }

        public override string ToString()
        {
            return $"infix {Assoc} {Power} {Name} = {Expression}";
        }

        public override void PP(Writer writer)
        {
            writer.WriteLine($"{this}");
        }
    }
}
