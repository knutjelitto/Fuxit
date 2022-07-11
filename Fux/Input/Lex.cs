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
            bool isParent = false)
        {
            Name = string.Intern(name);
            IsKeyword = isKeyword;
            StartsAtomic = startsAtomic;
            TerminatesSomething = terminatesSomething;
            IsIdentifier = isIdentifier;
            IsParent = isParent;
        }

        public string Name { get; }
        public bool IsKeyword { get; }
        public bool StartsAtomic { get; }
        public bool TerminatesSomething { get; }
        public bool IsIdentifier { get; }
        public bool IsParent { get; }

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
            BOF = Add(new("<BOF>"));
            EOF = Add(new("<EOF>", terminatesSomething: true));

            Newline = Add(new("_nl_"));
            Space = Add(new("_sp_"));
            LineComment = Add(new("_line-comment_"));
            BlockComment = Add(new("_block-comment_"));

            GroupOpen = Add(new("⟦", startsAtomic: true));
            GroupClose = Add(new("⟧"));

            LowerId = Add(new("LowerId", startsAtomic: true, isIdentifier: true));
            UpperId = Add(new("UpperId", startsAtomic: true, isIdentifier: true));
            OperatorId = Add(new("OperatorId", startsAtomic: true, isIdentifier: true));

            Wildcard = Add(new("_wildcard_", startsAtomic: true));
            Operator = Add(new("_operator_"));
            Integer = Add(new("Int", startsAtomic: true));
            Float = Add(new("Float", startsAtomic: true));
            String = Add(new("String", startsAtomic: true));
            LongString = Add(new("LongString", startsAtomic: true));
            Char = Add(new("Char", startsAtomic: true));
            Dot = Add(new(".", startsAtomic: true));
            Colon = Add(new(":", terminatesSomething: true));
            Assign = Add(new("=", terminatesSomething: true));
            Comma = Add(new(",", terminatesSomething: true));
            Arrow = Add(new("->", terminatesSomething: true));
            Bar = Add(new("|", terminatesSomething: true));
            Lambda = Add(new("\\", startsAtomic: true));
            LParent = Add(new("(", startsAtomic: true, isParent: true));
            RParent = Add(new(")", terminatesSomething: true, isParent: true));
            LBrace = Add(new("{", startsAtomic: true, isParent: true));
            RBrace = Add(new("}", terminatesSomething: true, isParent: true));
            LBracket = Add(new("[", startsAtomic: true, isParent: true));
            RBracket = Add(new("]", terminatesSomething: true, isParent: true));
            KwIf = Add(new("if", isKeyword: true, startsAtomic: true));
            KwThen = Add(new("then", isKeyword: true));
            KwElse = Add(new("else", isKeyword: true));
            KwCase = Add(new("case", isKeyword: true, startsAtomic: true));
            KwOf = Add(new("of", isKeyword: true));
            KwLet = Add(new("let", isKeyword: true, startsAtomic: true));
            KwIn = Add(new("in", isKeyword: true));
            KwType = Add(new("type", isKeyword: true));
            KwModule = Add(new("module", isKeyword: true));
            KwImport = Add(new("import", isKeyword: true));
            KwAs = Add(new("as", isKeyword: true));
            KwInfix = Add(new("infix", isKeyword: true));
        }

        public static readonly Lex BOF;
        public static readonly Lex EOF;
        public static readonly Lex Newline;
        public static readonly Lex Space;
        public static readonly Lex LineComment;
        public static readonly Lex BlockComment;
        public static readonly Lex GroupOpen;
        public static readonly Lex GroupClose;
        public static readonly Lex LowerId;
        public static readonly Lex UpperId;
        public static readonly Lex OperatorId;
        public static readonly Lex Wildcard;
        public static readonly Lex Operator;
        public static readonly Lex Integer;
        public static readonly Lex Float;
        public static readonly Lex String;
        public static readonly Lex LongString;
        public static readonly Lex Char;
        public static readonly Lex Dot;
        public static readonly Lex Colon;
        public static readonly Lex Assign;
        public static readonly Lex Comma;
        public static readonly Lex Arrow;
        public static readonly Lex Bar;
        public static readonly Lex Lambda;
        public static readonly Lex LParent;
        public static readonly Lex RParent;
        public static readonly Lex LBrace;
        public static readonly Lex RBrace;
        public static readonly Lex LBracket;
        public static readonly Lex RBracket;
        public static readonly Lex KwIf;
        public static readonly Lex KwThen;
        public static readonly Lex KwElse;
        public static readonly Lex KwCase;
        public static readonly Lex KwOf;
        public static readonly Lex KwLet;
        public static readonly Lex KwIn;
        public static readonly Lex KwType;
        public static readonly Lex KwModule;
        public static readonly Lex KwImport;
        public static readonly Lex KwAs;
        public static readonly Lex KwInfix;

        public static class Weak
        {
            public const string Exposing = "exposing";
            public const string Effect = "effect";
            public const string Port = "port";
            public const string Where = "where";
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
