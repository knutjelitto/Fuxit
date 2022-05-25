using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal static class ParserExtensions
    {
        public static bool Is(this LineCursor cursor, Lex lex)
        {
            return cursor.More() && cursor.Current.Lex == lex;
        }

        public static Token At(this LineCursor cursor)
        {
            return cursor.Current;
        }

    }
}
