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

        private ILocation Location => new Location(Lexer.Source, Lexer.Offset, 1);
    }
}
