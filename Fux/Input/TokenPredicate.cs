namespace Fux.Input
{
    internal static class TokenPredicate
    {
        public static bool IsOperator(this Token token)
        {
            return token.Lex == Lex.Operator;
        }

        public static bool IsLower(this Token token)
        {
            return token.Lex == Lex.LowerId;
        }

        public static bool IsUpper(this Token token)
        {
            return token.Lex == Lex.UpperId;
        }

        public static bool IsLiteral(this Token token)
        {
            return token.Lex == Lex.Number || token.Lex == Lex.String || token.Lex == Lex.Char;
        }
    }
}
