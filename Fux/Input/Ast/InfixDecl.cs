namespace Fux.Input.Ast
{
    internal class InfixDecl : Declaration
    {
        public InfixDecl(InfixAssoc assoc, InfixPower power, Identifier op, Identifier expression)
            : base(op)
        {
            Assoc = assoc;
            Precedence = power;
            Expression = expression;
        }

        public InfixAssoc Assoc { get; }
        public InfixPower Precedence { get; }
        public Identifier Expression { get; }
        public int Power => Precedence.Value;

        public override string ToString()
        {
            return $"infix {Assoc} {Precedence} {Name} = {Expression}";
        }

        public override void PP(Writer writer)
        {
            writer.WriteLine($"{this}");
        }
    }
}
