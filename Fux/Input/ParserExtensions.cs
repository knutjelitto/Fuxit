namespace Fux.Input
{
    internal static class ParserExtensions
    {
        public static bool Is(this TokensCursor cursor, Lex lex)
        {
            return cursor.More() && cursor.Current.Lex == lex;
        }

        public static bool IsIdentifier(this TokensCursor cursor)
        {
            return cursor.More() &&
                (cursor.Current.Lex == Lex.LowerId || cursor.Current.Lex == Lex.UpperId || cursor.Current.Lex == Lex.OperatorId);
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
