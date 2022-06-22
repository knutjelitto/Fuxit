using System.Globalization;

namespace Fux.Input.Ast
{
    internal abstract class Literal : Expression
    {
        public Literal(Token token)
        {
            Token = token;
        }

        public Token Token { get; }

        public override string ToString()
        {
            return $"{Token}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Token}");
        }
    }

    internal sealed class IntegerLiteral : Literal
    {
        public IntegerLiteral(Token token)
            : base(token)
        {
            Assert(token.Lex == Lex.Integer);

            var text = Token.Text;

            if (text.StartsWith("0x"))
            {
                Value = long.Parse(text.Substring(2), NumberStyles.HexNumber);
            }
            else
            {
                Value = long.Parse(text, NumberStyles.Integer);
            }
        }

        public long Value { get; }
    }

    internal sealed class FloatLiteral : Literal
    {
        public FloatLiteral(Token token)
            : base(token)
        {
            Assert(token.Lex == Lex.Float);
        }
    }
    internal class CharLiteral : Literal
    {
        public CharLiteral(Token token)
            : base(token)
        {
            Assert(token.Lex == Lex.Char);
        }
    }
    internal class StringLiteral : Literal
    {
        public StringLiteral(Token token)
            : base(token)
        {
            Assert(token.Lex == Lex.String);
        }
    }
}
