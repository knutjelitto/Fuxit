namespace Fux.Input.Ast
{
    internal class InfixPower
    {
        public InfixPower(Token number)
        {
            Assert(number.Lex == Lex.Number);

            Number = number;

            Value = int.Parse(Number.Text) * 10;
        }

        public Token Number { get; }

        public int Value { get; }

        public override string ToString() => $"{Number}";
    }
}
