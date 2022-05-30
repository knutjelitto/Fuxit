namespace Fux.Input
{
    internal class Liner
    {
        private Token? current = null;

        private readonly TokenList allTokens = new();

        public Liner(ErrorBag errors, Lexer lexer)
        {
            Errors = errors;
            Lexer = lexer;
            Error = new ParserErrors(errors);
        }

        public ErrorBag Errors { get; }
        public Lexer Lexer { get; }

        public ParserErrors Error { get; }

        public Tokens GetLine()
        {
            if (Current.EOF)
            {
                Assert(allTokens[^1].Lex == Lex.EOF);
                return new Tokens().Add(Current);
            }

            try
            {
                return ParseLine();
            }
            catch (DiagnosticException diagnostic)
            {
                Errors.Add(diagnostic);

                return new Tokens();
            }
        }

        private Token Current
        {
            get
            {
                if (current == null)
                {
                    current = CreateNextToken();
                }
                return current;
            }
        }

        private Token Consume()
        {
            var token = Current;

            current = null;

            return token;
        }

        private Tokens ParseLine()
        {
            var starter = Current;

            var tokens = new Tokens();

            while (!Current.EOF && Current.Line == starter.Line)
            {
                var token = Consume();

                tokens.Add(token);
            }

            if (!Current.EOF && Current.Column > starter.Column)
            {
                ParseLines(tokens);
            }

            return tokens;
        }

        private void ParseLines(Tokens parent)
        {
            var starter = Current;

            while (!Current.EOF && Current.Column == starter.Column)
            {
                var line = ParseLine();

                if (parent.EndsWith(Lex.Operator))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.EndsWith(Lex.Colon))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.EndsWith(Lex.Define))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.EndsWith(Lex.Arrow))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.EndsWith(Lex.KwIn))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.EndsWith(Lex.KwOf))
                {
                    parent.AppendGrouped(line);

                    continue;
                }
                else if (parent.EndsWith(Lex.KwIf))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.EndsWith(Lex.KwThen))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.EndsWith(Lex.KwElse))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.EndsWith(Lex.LParent))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.StartsWith(Lex.KwModule))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.StartsWith(Lex.KwImport))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.StartsWith(Lex.KwOf))
                {
                    parent.AppendGrouped(line);

                    continue;
                }
                else if (parent.StartsWith(Lex.KwIf))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.StartsWith(Lex.KwThen))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.StartsWith(Lex.KwElse))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.StartsWith(Lex.KwIn))
                {
                    parent.Append(line);

                    continue;
                }
                else if (parent.StartsWith(Lex.KwLet))
                {
                    parent.AppendGrouped(line);

                    continue;
                }
                else if (parent.StartsWith(Lex.KwCase))
                {
                    parent.AppendGrouped(line);

                    continue;
                }
                else if (line.StartsWith(Lex.KwOf))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.StartsWith(Lex.Operator))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.StartsWith(Lex.LParent))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.StartsWith(Lex.LBrace))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.StartsWith(Lex.LBracket))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.StartsWith(Lex.RParent))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.StartsWith(Lex.RBrace))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.StartsWith(Lex.RBracket))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.StartsWith(Lex.Comma))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.StartsWith(Lex.Colon))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.StartsWith(Lex.Define))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.StartsWith(Lex.Arrow))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.StartsWith(Lex.KwIn))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.StartsWith(Lex.KwElse))
                {
                    parent.Append(line);

                    continue;
                }
                else if (line.IsAtomic)
                {
                    parent.Append(line);

                    continue;
                }
                else
                {
                    Assert(false);

                    throw new NotImplementedException();
                }
            }
        }

        private Token CreateNextToken()
        {
            var whites = new Whites();
            var current = allTokens.Add(Lexer.GetNext());

            while (!current.EOF && current.White)
            {
                whites.Add(current);

                current = allTokens.Add(Lexer.GetNext());
            }

            return current.TransferWhites(whites);
        }
    }
}
