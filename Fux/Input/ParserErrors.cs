using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal class ParserErrors
    {
        public ParserErrors(Parser parser)
        {
            Parser = parser;
        }

        public Parser Parser { get; }

        public DiagnosticException NotImplemented(Token current, [CallerMemberName]string? member = null)
        {
            var text = string.IsNullOrEmpty(current.Text) ? current.Lex.Name : current.Text;
            return new DiagnosticException(
                new ParserError(current.Location, $"{member} - not implemented at `{text}´"));
        }

        public DiagnosticException Unexpected(Lex expected, Token unexpected)
        {
            return new DiagnosticException(
                new ParserError(unexpected.Location, $"unexpected {unexpected.Lex.PP()} (expecting {expected.PP()})"));
        }

        public DiagnosticException Unexpected(Token unexpected, string? context)
        {
            context = context == null ? "" : $" (in {context})";
            return new DiagnosticException(
                new ParserError(unexpected.Location, $"unexpected {unexpected.Lex.PP()}{context}"));
        }
    }
}
