namespace Fux.Input
{
    public static class LexerPredicates
    {
        private static readonly HashSet<int> symbols = new()
        {
            '+',  '-',  '*',  '/',
            '%',  '^',  '$',  '&',
            '~',  '!',  '\\', '#',
            '=',  '.',  ':',  '?',
            '<',  '>',  '|',
        };

        public static bool IsCharacter(this int rune) => IsUnicode(rune) && !IsControl(rune) && !IsSurrogate(rune) && !IsBidi(rune);
        public static bool IsUnicode(this int rune) => 0x00 <= rune && rune <= 0x10FFFF;
        public static bool IsControl(this int rune) => 0x00 <= rune && rune <= 0x1F || 0x7F == rune || 0x80 <= rune && rune <= 0x9F;
        public static bool IsSurrogate(this int rune) => 0xD800 <= rune && rune <= 0xDFFF;
        public static bool IsBidi(this int rune) => 0x200E == rune || 0x200F == rune || 0x202A <= rune && rune <= 0x202E || 0x2066 <= rune && rune <= 0x2069;
        public static bool IsLower(this int rune) => 'a' <= rune && rune <= 'z';
        public static bool IsUpper(this int rune) => 'A' <= rune && rune <= 'Z';
        public static bool IsLetter(this int rune) => 'a' <= rune && rune <= 'z' || 'A' <= rune && rune <= 'Z';
        public static bool IsDigit(this int rune) => '0' <= rune && rune <= '9';
        public static bool IsLetterOrDigit(this int rune) => 'a' <= rune && rune <= 'z' || 'A' <= rune && rune <= 'Z' || '0' <= rune && rune <= '9';
        public static bool IsPosDigit(this int rune) => '1' <= rune && rune <= '9';
        public static bool IsHexDigit(this int rune) => 'a' <= rune && rune <= 'f' || 'A' <= rune && rune <= 'F' || IsDigit(rune);
        public static bool IsSymbol(this int rune) => symbols.Contains(rune);
    }
}
