namespace Fux.Input
{
    internal class Lex
    {
        private Lex(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public bool IsKeyword => char.IsLower(Name[0]);
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
        public static Lex LayoutStart = new("«");
        public static Lex LayoutEnd = new("»");
        public static Lex GroupStart = new("«");
        public static Lex GroupEnd = new("»");

        public static Lex LowerId = new("_lower-id_");
        public static Lex UpperId = new("_upper-id_");
        public static Lex Operator = new("_operator_");
        public static Lex Wildcard = new("_wildcard_");

        public static Lex Number = new("_number_");
        public static Lex String = new("_string_");

        public static Lex Colon = new(":");
        public static Lex Define = new Lex("=");
        public static Lex Semicolon = new(";");
        public static Lex Comma = new(",");
        public static Lex Dot = new(".");

        public static Lex LParent = new("(");
        public static Lex RParent = new(")");
        public static Lex LBrace = new("{");
        public static Lex RBrace = new("}");
        public static Lex LBracket = new("[");
        public static Lex RBracket = new("]");

        public static Lex KwModule = new("module");
        public static Lex KwExposing = new("exposing");
        public static Lex KwImport = new("import");
        public static Lex KwType = new("type");
        public static Lex KwIf = new("if");
        public static Lex KwThen = new("then");
        public static Lex KwElse = new("else");
        public static Lex KwLet = new("let");
        public static Lex KwIn = new("in");
        public static Lex KwCase = new("case");
    }
}
