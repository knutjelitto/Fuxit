namespace Fux.Input.Ast
{
    internal class InfixPower
    {
        public InfixPower(Token number)
        {
            Assert(number.Lex == Lex.Number);

            Number = number;
        }

        public Token Number { get; }

        public override string ToString() => $"{Number}";
    }
}
