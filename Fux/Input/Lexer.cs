#pragma warning disable IDE1006 // Naming Styles

namespace Fux.Input
{
    internal class Lexer
    {
        private static readonly Dictionary<string, (string name, Lex kwLex)> keywords = new();

        static Lexer()
        {
            AddKw("module", Lex.KwModule);
            AddKw("exposing", Lex.KwExposing);
            AddKw("import", Lex.KwImport);

            AddKw("type", Lex.KwType);

            AddKw("if", Lex.KwIf);
            AddKw("then", Lex.KwThen);
            AddKw("else", Lex.KwElse);

            AddKw("let", Lex.KwLet);
            AddKw("in", Lex.KwIn);

            AddKw("case", Lex.KwCase);
        }

        public Lexer(Source source)
        {
            Source = source;
            Offset = 0;
            Error = new LexerErrors(this);
        }

        public Source Source { get; }
        public int Offset { get; private set; }
        public int Start { get; private set; }

        private int Current => Source.Ensure(Offset);
        private int Next => Source.Ensure(Offset + 1);
        private int Previous => Source.Ensure(Offset - 1);

        private int At(int offset) => Source.Ensure(Offset + offset);

        public LexerErrors Error { get; }

        public Token Eof()
        {
            return Build(Lex.EOF);
        }

        public Token Bof()
        {
            return new Token(Lex.BOF, new Location(Source, 0, 0));
        }

        public Token GetNext()
        {
            Start = Offset;
            if (Current == 0x0A) // linefeed
            {
                return Build(Lex.Newline, 1);
            }
            if (Current == 0x0D && Next == 0x0A) // return linefeed
            {
                return Build(Lex.Newline, 2);
            }
            while (Current == ' ') // space
            {
                Offset += 1;
            }
            if (Offset > Start)
            {
                return Build(Lex.Space);
            }

            switch (Current)
            {
                case '(':
                    return LeftParentOrSymbol();
                case ')':
                    return Build(Lex.RParent, 1);
                case '{' when Next == '-':
                    return BlockComment();
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
                case ',':
                    return Build(Lex.Comma, 1);
                case ':' when !Next.IsSymbol():
                    return Build(Lex.Colon, 1);
                case '=' when !Next.IsSymbol():
                    return Build(Lex.Define, 1);
                case '-' when Next == '-':
                    return LineComment();
                case '-' when Next.IsDigit():
                    return Build(Number());
                case '"':
                    return String();
                case '_':
                    return Wildcard();
                default:
                    if (Current.IsLower())
                    {
                        return LowerId();
                    }
                    else if (Current.IsUpper())
                    {
                        return Build(UpperId());
                    }
                    else if (Current.IsDigit())
                    {
                        return Build(Number());
                    }
                    else if (Current.IsSymbol())
                    {
                        return Build(Operator());
                    }
                    break;
            }

            if (Source.EOS)
            {
                return Build(Lex.EOF);
            }

            throw Error.Unexpected(Current);
        }

        private Token LeftParentOrSymbol()
        {
            Assert(Current == '(');

            if (Next.IsSymbol())
            {
                var offset = 1;

                do
                {
                    offset += 1;
                }
                while (At(offset).IsSymbol());

                if (At(offset) == ')')
                {
                    var token = Build(Lex.LowerId, offset + 1);

                    return token;
                }
            }

            return Build(Lex.LParent, 1);
        }

        private Token Wildcard()
        {
            Assert(Current == '_');

            return Build(Lex.Wildcard, 1);
        }

        private Token BlockComment()
        {
            Assert(Current == '{' && Next == '-');

            Offset += 2;

            while (true)
            {
                if (Current == '{' && Next == '-')
                {
                    BlockComment();
                }
                else if (Current == '-' && Next == '}')
                {
                    return Build(Lex.BlockComment, 2);
                }
                else
                {
                    if (Current == '\n')
                    {
                        Source.NextLine(Offset + 1);
                    }
                    Offset += 1;
                }
            }
        }

        private Token LineComment()
        {
            Assert(Current == '-' && Next == '-');

            Offset += 2;

            while (true)
            {
                if (Current == '\n' || Current == '\r' || Current == '\0')
                {
                    return Build(Lex.LineComment);
                }
                else
                {
                    Offset += 1;
                }
            }
        }

        private Lex Operator()
        {
            Assert(Current.IsSymbol());

            Offset += 1;

            while (Current.IsSymbol())
            {
                Offset += 1;
            }

            return Lex.Operator;
        }

        private Lex Number()
        {
            if (Current == '-')
            {
                Offset += 1;
            }

            Assert(Current.IsDigit());

            Offset += 1;

            if (Current == 'x')
            {
                Offset += 1;

                while (Current.IsHexDigit())
                {
                    Offset += 1;
                }
            }
            else
            {
                while (Current.IsDigit())
                {
                    Offset += 1;
                }
            }

            return Lex.Number;
        }

        private Token String()
        {
            Assert(Current == '"');
            Offset += 1;

            while(Current != '"')
            {
                switch (Current)
                {
                    case '\\':
                        Escape();
                        break;
                    default:
                        if (Current.IsCharacter())
                        {
                            Offset += 1;
                        }
                        else
                        {
                            if (Current == '\0')
                            {
                                throw new NotImplementedException("unexpected end in string literal");
                            }
                            throw new NotImplementedException("illegal character in string literal");
                        }
                        break;
                }
            }

            Assert(Current == '"');

            Offset += 1;

            return Build(Lex.String);
        }

        private void Escape()
        {
            Assert(Current == '\\');

            Offset += 1;

            switch (Current)
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
                    Swallow(rune => rune.IsHexDigit());
                    Swallow(rune => rune.IsHexDigit());
                    break;
                case 'u':
                    Offset += 1;
                    Swallow(rune => rune.IsHexDigit());
                    Swallow(rune => rune.IsHexDigit());
                    Swallow(rune => rune.IsHexDigit());
                    Swallow(rune => rune.IsHexDigit());
                    break;
                case 'U':
                    Offset += 1;
                    Swallow(rune => rune.IsHexDigit());
                    Swallow(rune => rune.IsHexDigit());
                    Swallow(rune => rune.IsHexDigit());
                    Swallow(rune => rune.IsHexDigit());
                    Swallow(rune => rune.IsHexDigit());
                    Swallow(rune => rune.IsHexDigit());
                    break;
                default:
                    Assert(false);
                    break;
            }
        }

        private int Swallow(Func<int, bool> predicate)
        {
            if (predicate(Current))
            {
                var current = Current;

                Offset += 1;

                return current;
            }

            throw new NotImplementedException($"can't match current character");
        }

        private int Swallow(int rune)
        {
            return Swallow(current => current == rune);
        }

        private Token LowerId()
        {
            Assert(Current.IsLower());

            IdTail();

            var token = Build(Lex.LowerId);

            if (keywords.TryGetValue(token.Text, out var tuple))
            {
                token = new Token(tuple.kwLex, token);
            }

            return token;
        }

        private Lex UpperId()
        {
            Assert(Current.IsUpper());

            IdTail();

            return Lex.UpperId;
        }

        private void IdTail()
        {
            Offset += 1;
            while (Current.IsLower() || Current.IsUpper() || Current.IsDigit() || Current == '_' || Current == '-')
            {
                if (Current == '-' && (!Previous.IsLetter() || !Next.IsLetter()))
                {
                    break;
                }

                Offset += 1;
            }
        }

        private Token Build(Lex lex, int plus = 0)
        {
            Offset += plus;
            if (lex == Lex.Newline)
            {
                Source.NextLine(Offset);
            }
            return new Token(lex, new Location(Source, Start, Offset - Start));
        }

        private static void AddKw(string name, Lex kwLex)
        {
            keywords.Add(name, (name, kwLex));
        }
    }
}
