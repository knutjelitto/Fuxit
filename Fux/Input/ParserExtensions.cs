using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal static class ParserExtensions
    {
        public static bool Is(this TokensCursor cursor, Lex lex)
        {
            return cursor.More() && cursor.Current.Lex == lex;
        }

        public static bool IsWeak(this TokensCursor cursor, string text)
        {
            return cursor.More() && cursor.Current.Text == text;
        }

        public static bool IsNot(this TokensCursor cursor, Lex lex)
        {
            return cursor.More() && cursor.Current.Lex != lex;
        }

        public static Token At(this TokensCursor cursor)
        {
            return cursor.Current;
        }

        public static bool IsOperator(this TokensCursor cursor)
        {
            return cursor.More() && cursor.Current.IsOperator();
        }

    }
}
