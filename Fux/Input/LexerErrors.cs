using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class LexerErrors
    {
        public LexerErrors(Lexer lexer)
        {
            Lexer = lexer;
        }

        public Lexer Lexer { get; }

        public DiagnosticException Unexpected(int rune)
        {
            return new DiagnosticException(
                new LexerError(Location, $"unexpected character `{(char)rune}´"));
        }

        public DiagnosticException IllegalWhitespace(Token token)
        {
            return new DiagnosticException(
                new LexerError(token.Location, $"illegal whitespace before {token}"));
        }

        private ILocation Location => new Location(Lexer.Source, Lexer.Offset, 1);
    }
}
