namespace Fux.Input
{
    public sealed class Lex
    {
        public static readonly List<Lex> allLex = new();

        private Lex(string name,
            bool isKeyword = false, 
            bool startsAtomic = false, 
            bool terminatesSomething = false,
            bool isIdentifier = false,
            bool isBracket = false)
        {
            Name = string.Intern(name);
            IsKeyword = isKeyword;
            StartsAtomic = startsAtomic;
            TerminatesSomething = terminatesSomething || isKeyword;
            IsIdentifier = isIdentifier;
            IsBracket = isBracket;
        }

        public string Name { get; }
        public bool IsKeyword { get; }
        public bool StartsAtomic { get; }
        public bool TerminatesSomething { get; }
        public bool IsIdentifier { get; }
        public bool IsBracket { get; }

        public static IReadOnlyList<Lex> AllLex => allLex;

        public string PP()
        {
            if (IsKeyword)
            {
                return $"keyword `{Name}´";
            }
            return $"token `{Name}´";
        }

        public override string ToString()
        {
            return Name;
        }

        private static Lex Add(Lex lex)
        {
            allLex.Add(lex);

            return lex;
        }

        static Lex()
        {
        }

        public static readonly Lex BOF = Add(new("<BOF>"));
        public static readonly Lex EOF = Add(new("<EOF>", terminatesSomething: true));
        public static readonly Lex Newline = Add(new("_nl_"));
        public static readonly Lex Space = Add(new("_sp_"));
        public static readonly Lex LineComment = Add(new("_line-comment_"));
        public static readonly Lex BlockComment = Add(new("_block-comment_"));
        public static readonly Lex GroupOpen = Add(new("⟦", startsAtomic: true));
        public static readonly Lex GroupClose = Add(new("⟧"));
        public static readonly Lex LowerId = Add(new("LowerId", startsAtomic: true, isIdentifier: true));
        public static readonly Lex UpperId = Add(new("UpperId", startsAtomic: true, isIdentifier: true));
        public static readonly Lex OperatorId = Add(new("OperatorId", startsAtomic: true, isIdentifier: true));
        public static readonly Lex Wildcard = Add(new("_wildcard_", startsAtomic: true));
        public static readonly Lex Operator = Add(new("_operator_"));
        public static readonly Lex Integer = Add(new("Int", startsAtomic: true));
        public static readonly Lex Float = Add(new("Float", startsAtomic: true));
        public static readonly Lex String = Add(new("String", startsAtomic: true));
        public static readonly Lex LongString = Add(new("LongString", startsAtomic: true));
        public static readonly Lex Char = Add(new("Char", startsAtomic: true));
        public static readonly Lex Dot = Add(new(".", startsAtomic: true));
        public static readonly Lex Colon = Add(new(":", terminatesSomething: true));
        public static readonly Lex Assign = Add(new("=", terminatesSomething: true));
        public static readonly Lex Comma = Add(new(",", terminatesSomething: true));
        public static readonly Lex Arrow = Add(new("->", terminatesSomething: true));
        public static readonly Lex Bar = Add(new("|", terminatesSomething: true));
        public static readonly Lex Lambda = Add(new("\\", startsAtomic: true));
        public static readonly Lex LeftRoundBracket = Add(new("(", startsAtomic: true, isBracket: true));
        public static readonly Lex RightRoundBracket = Add(new(")", terminatesSomething: true, isBracket: true));
        public static readonly Lex LeftCurlyBracket = Add(new("{", startsAtomic: true, isBracket: true));
        public static readonly Lex RCurlyBracket = Add(new("}", terminatesSomething: true, isBracket: true));
        public static readonly Lex LeftSquareBracket = Add(new("[", startsAtomic: true, isBracket: true));
        public static readonly Lex RightSquareBracket = Add(new("]", terminatesSomething: true, isBracket: true));
        public static readonly Lex KwIf = Add(new("if", isKeyword: true, startsAtomic: true));
        public static readonly Lex KwThen = Add(new("then", isKeyword: true));
        public static readonly Lex KwElse = Add(new("else", isKeyword: true));
        public static readonly Lex KwCase = Add(new("case", isKeyword: true, startsAtomic: true));
        public static readonly Lex KwOf = Add(new("of", isKeyword: true));
        public static readonly Lex KwLet = Add(new("let", isKeyword: true, startsAtomic: true));
        public static readonly Lex KwIn = Add(new("in", isKeyword: true));
        public static readonly Lex KwType = Add(new("type", isKeyword: true));
        public static readonly Lex KwModule = Add(new("module", isKeyword: true));
        public static readonly Lex KwImport = Add(new("import", isKeyword: true));
        public static readonly Lex KwAs = Add(new("as", isKeyword: true));
        public static readonly Lex KwInfix = Add(new("infix", isKeyword: true));
        public static readonly Lex KwAlias = Add(new("alias", isKeyword: true));
        public static readonly Lex KwEffect = Add(new("effect", isKeyword: true));
        public static readonly Lex KwExposing = Add(new("exposing", isKeyword: true));
        public static readonly Lex KwPort = Add(new("port", isKeyword: true));
        public static readonly Lex KwWhere = Add(new("where", isKeyword: true));
        public static readonly Lex KwClass = Add(new("class", isKeyword: true));

        public static class Weak
        {
            public const string ExposeAll = "(..)";
        }

        public static class CoreModule
        {
            public const string List = "List";
        }


        public static class Primitive
        {
            public const string Int = "Int";
            public const string Float = "Float";
            public const string Bool = "Bool";
            public const string String = "String";
            public const string Char = "Char";
            public const string List = "List";
        }

        public static class Symbol
        {
            public const string Wildcard = "_";
            public const string Unit = "()";
            public const string Empty = "[]";
            public const string Cons = "::";
            public const string ListCons = "(::)";
        }

        public static class Term
        {
            public const string Type = "Type";
        }
    }
}
