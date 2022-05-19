using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE0028 // Simplify collection initialization

namespace Fux.Input
{
    internal class Lexer
    {
        private static readonly HashSet<int> specials = new()
        {
            '{', '}',
            '(', ')',
            '[', ']',
            '|', ';', ',',
        };

        private static readonly HashSet<int> symbols = new()
        {
            '$', '%', '&', '*', '+',
            '~', '!', '\\', '^', '#',
            '=', '.', ':', '-', '?',
            '<', '>', '|',
        };

        public Lexer(Source source)
        {
            Source = source;

            Offset = 0;

            Lines = new List<int>();
            Lines.Add(0);
        }

        public Source Source { get; }

        public int Offset { get; private set; }
        public int Start { get; private set; }
        public int Length { get; }

        public int This => Ensure(Offset);
        public int Next => Ensure(Offset + 1);
        public int Prev => Ensure(Offset - 1);

        public List<int> Lines { get; }

        private char Ensure(int offset)
        {
            return Source.Ensure(offset);
        }

        public Token Eof()
        {
            return Build(Lex.EOF);
        }

        public Token Bof()
        {
            return new Token(this, Lex.BOF, 0, 0);
        }

        public Token Scan()
        {
            Start = Offset;
            if (This == 0x0A) // linefeed
            {
                return Build(Lex.Newline, 1);
            }
            if (This == 0x0D && Next == 0x0A) // return linefeed
            {
                return Build(Lex.Newline, 2);
            }
            while (This == ' ') // space
            {
                Offset += 1;
            }
            if (Offset > Start)
            {
                return Build(Lex.Space);
            }

            switch (This)
            {
                case '(':
                    return Build(Lex.LParent, 1);
                case ')':
                    return Build(Lex.RParent, 1);
                case '{':
                    return Build(Lex.LBrace, 1);
                case '}':
                    return Build(Lex.RBrace, 1);
                case '[':
                    return Build(Lex.LBracket, 1);
                case ']':
                    return Build(Lex.RBracket, 1);
                case ';':
                    return Build(Lex.Semicolon, 1);
                case '-' when IsDigit(Next):
                    return Build(Number());
                case '"':
                    return String();
                default:
                    if (IsLower(This))
                    {
                        return Build(LowerId());
                    }
                    else if (IsUpper(This))
                    {
                        return Build(UpperId());
                    }
                    else if (IsDigit(This))
                    {
                        return Build(Number());
                    }
                    else if (IsSymbol(This))
                    {
                        return Build(Operator());
                    }
                    break;
            }

            throw new NotImplementedException();
        }

        private Lex Operator()
        {
            Assert(isSymbol);

            Offset += 1;

            while (isSymbol)
            {
                Offset += 1;
            }

            return Lex.Operator;
        }

        private Lex Number()
        {
            Assert(This == '-' && IsDigit(Next) || IsDigit(This));

            Offset += 1;

            while (IsDigit(This))
            {
                Offset += 1;
            }

            return Lex.Number;
        }

        private Token String()
        {
            Assert(This == '"');
            Offset += 1;

            while(This != '"')
            {
                switch (This)
                {
                    case '\\':
                        Escape();
                        break;
                    default:
                        if (IsCharacter(This))
                        {
                            Offset += 1;
                        }
                        else
                        {
                            if (This == '\0')
                            {
                                throw new NotImplementedException("unexpected end in string literal");
                            }
                            throw new NotImplementedException("illegal character in string literal");
                        }
                        break;
                }
            }

            Assert(This == '"');

            Offset += 1;

            return Build(Lex.String);
        }

        private void Escape()
        {
            Assert(This == '\\');

            Offset += 1;

            switch (This)
            {
                case 'n':
                case 'r':
                case 't':
                case '\\':
                case '\'':
                case '\"':
                    Offset += 1;
                    break;
                case 'x':
                    Offset += 1;
                    Swallow(IsHexDigit);
                    Swallow(IsHexDigit);
                    break;
                case 'u':
                    Offset += 1;
                    Swallow(IsHexDigit);
                    Swallow(IsHexDigit);
                    Swallow(IsHexDigit);
                    Swallow(IsHexDigit);
                    break;
                case 'U':
                    Offset += 1;
                    Swallow(IsHexDigit);
                    Swallow(IsHexDigit);
                    Swallow(IsHexDigit);
                    Swallow(IsHexDigit);
                    Swallow(IsHexDigit);
                    Swallow(IsHexDigit);
                    break;
                default:
                    Assert(false);
                    break;
            }
        }

        private int Swallow(Func<int, bool> predicate)
        {
            if (predicate(This))
            {
                var current = This;

                Offset += 1;

                return current;
            }

            throw new NotImplementedException($"can't match current character");
        }

        private Lex LowerId()
        {
            Assert(IsLower(This));

            IdTail();

            return Lex.LowerId;
        }

        private Lex UpperId()
        {
            Assert(IsUpper(This));

            IdTail();

            return Lex.UpperId;
        }

        private void IdTail()
        {
            Offset += 1;
            while (IsLower(This) || IsUpper(This) || IsDigit(This) || This == '_' || This == '-')
            {
                if (This == '-' && (!IsLetter(Prev) || !IsLetter(Next)))
                {
                    break;
                }

                Offset += 1;
            }
        }

        private Token Build(Lex lex, int plus = 0)
        {
            Offset += plus;
            return new Token(this, lex, Start, Offset);
        }

        private Lex Swallow(Lex lex)
        {
            Offset += 1;
            return lex;
        }

        private bool IsCharacter(int rune) => IsUnicode(rune) && !IsControl(rune) && !IsSurrogate(rune) && !IsBidi(rune);
        private bool IsUnicode(int rune) => 0x00 <= rune && rune <= 0x10FFFF;
        private bool IsControl(int rune) => 0x00 <= rune && rune <= 0x1F || 0x7F == rune || 0x80 <= rune && rune <= 0x9F;
        private bool IsSurrogate(int rune) => 0xD800 <= rune && rune <= 0xDFFF;
        private bool IsBidi(int rune) => 0x200E == rune || 0x200F == rune || 0x202A <= rune && rune <= 0x202E || 0x2066 <= rune && rune <= 0x2069;
        private bool isSymbol => symbols.Contains(This);
        private bool isSpecial => specials.Contains(This);

        private bool IsLower(int rune) => 'a' <= rune && rune <= 'z';
        private bool IsUpper(int rune) => 'A' <= rune && rune <= 'Z';
        private bool IsLetter(int rune) => IsLower(rune) || IsUpper(rune);
        private bool IsDigit(int rune) => '0' <= rune && rune <= '9';
        private bool IsPosDigit(int rune) => '1' <= rune && rune <= '9';
        private bool IsHexDigit(int rune) => 'a' <= rune && rune <= 'f' || 'A' <= rune && rune <= 'F' || IsDigit(rune);
        private bool IsSymbol(int rune) => symbols.Contains(rune);
    }
}
