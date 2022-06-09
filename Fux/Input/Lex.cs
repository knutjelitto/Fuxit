namespace Fux.Input
{
    internal class Lex
    {
        private Lex(string name, bool isKeyword = false, bool startsAtomic = false)
        {
            Name = name;
            IsKeyword = isKeyword;
            StartsAtomic = startsAtomic;
        }

        public string Name { get; }
        public bool IsKeyword { get; }
        public bool StartsAtomic { get; }

        public bool IsOperator => ((int)Name[0]).IsSymbol();

        public string PP()
        {
            if (IsKeyword)
            {
                return $"keyword `{Name}´";
            }
            return $"token `{Name}´";
        }

        public override bool Equals(object? obj)
        {
            return obj is Lex other && other.Name == Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }

        public static Lex BOF = new("<BOF>");
        public static Lex EOF = new("<EOF>");

        public static Lex Newline = new("_nl_");
        public static Lex Space = new("_sp_");
        public static Lex LineComment = new("_line-comment_");
        public static Lex BlockComment = new("_block-comment_");

        public static Lex GroupOpen = new("⟦", startsAtomic: true);
        public static Lex GroupClose = new("⟧");

        public static Lex LowerId = new("LowerId", startsAtomic: true);
        public static Lex UpperId = new("UpperId", startsAtomic: true);
        public static Lex OperatorId = new("OperatorId", startsAtomic: true);
        public static Lex Wildcard = new("_wildcard_", startsAtomic: true);
        public static Lex Operator = new("_operator_");

        public static Lex Number = new("_number_", startsAtomic: true);
        public static Lex String = new("_string_", startsAtomic: true);
        public static Lex Char = new("_char_", startsAtomic: true);

        public static Lex Dot = new(".");
        public static Lex Colon = new(":");
        public static Lex Assign = new("=");
        public static Lex Comma = new(",");
        public static Lex Arrow = new("->");
        public static Lex Bar = new("|");
        public static Lex Lambda = new("\\", startsAtomic: true);

        public static Lex LParent = new("(", startsAtomic: true);
        public static Lex RParent = new(")");
        public static Lex LBrace = new("{", startsAtomic: true);
        public static Lex RBrace = new("}");
        public static Lex LBracket = new("[", startsAtomic: true);
        public static Lex RBracket = new("]");

        public static Lex HardKwIf = new("if", isKeyword: true, startsAtomic: true);
        public static Lex HardKwThen = new("then", isKeyword: true);
        public static Lex HardKwElse = new("else", isKeyword: true);
        public static Lex HardKwCase = new("case", isKeyword: true, startsAtomic: true);
        public static Lex HardKwOf = new("of", isKeyword: true);
        public static Lex HardKwLet = new("let", isKeyword: true, startsAtomic: true);
        public static Lex HardKwIn = new("in", isKeyword: true);

        public static Lex HardKwType = new("type", isKeyword: true);
        public static Lex HardKwModule = new("module", isKeyword: true);
        public static Lex HardKwImport = new("import", isKeyword: true);
        public static Lex HardKwAs = new("as", isKeyword: true);

        public static Lex HardKwInfix = new("infix", isKeyword: true);

        public static class Weak
        {
            public const string Exposing = "exposing";
            public const string Effect = "effect";
            public const string Port = "port";
            public const string ExposeAll = "(..)";
        }

        public static class Term
        {
            public const string Type = "Type";
        }
    }
}
