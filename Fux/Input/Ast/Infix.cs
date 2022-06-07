namespace Fux.Input.Ast
{
    internal class Infix
    {
        public static readonly Infix Instance = new Infix();

        private readonly Dictionary<string, Prec> precs = new();

        private Infix()
        {
            Add("|", 20, Assoc.None);

            Add("<|", 100, Assoc.Right);
            Add("|>", 100, Assoc.Left);

            Add("||", 120, Assoc.Right);
            Add("&&", 130, Assoc.Right);

            Add("==", 140, Assoc.None);
            Add("!=", 140, Assoc.None);
            Add("/=", 140, Assoc.None);

            Add("<", 140, Assoc.None);
            Add("<=", 140, Assoc.None);
            Add(">", 140, Assoc.None);
            Add(">=", 140, Assoc.None);

            Add("++", 150, Assoc.Right);
            Add("|=", 150, Assoc.Left);

            Add("+", 160, Assoc.Left);
            Add("-", 160, Assoc.Left);
            Add("::", 160, Assoc.Left);
            Add("|.", 160, Assoc.Left);

            Add("*", 170, Assoc.Left);
            Add("/", 170, Assoc.Left);
            Add("//", 170, Assoc.Left);

            Add("^", 180, Assoc.Right);

            Add("<<", 190, Assoc.Left);
            Add(">>", 190, Assoc.Right);
        }

        public Prec this[string name]
        {
            get
            {
                return precs[name];
            }
        }

        public OperatorSymbol Create(Token token)
        {
            if (precs.TryGetValue(token.Text, out var prec) && prec.Create != null)
            {
                return prec.Create(token);
            }
            return new OperatorSymbol(token);
        }

        private void Add(string name, int prio, Assoc assoc, Func<Token, OperatorSymbol>? create = null)
        {
            precs.Add(name, new Prec(name, prio, assoc, create));
        }

        public class Prec
        {
            public Prec(string name, int prio, Assoc assoc, Func<Token, OperatorSymbol>? create = null)
            {
                Name = name;
                Precedence = prio;
                Assoc = assoc;
                Create = create;
            }

            public string Name { get; }
            public int Precedence { get; }
            public Assoc Assoc { get; }
            public Func<Token, OperatorSymbol>? Create { get; }
        }

        public enum Assoc
        {
            None,
            Left,
            Right,
        }
    }
}
