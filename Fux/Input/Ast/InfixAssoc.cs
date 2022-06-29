namespace Fux.Input.Ast
{
    public sealed class InfixAssoc
    {
        private InfixAssoc(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static readonly InfixAssoc None = new("non");
        public static readonly InfixAssoc Left = new("left");
        public static readonly InfixAssoc Right = new("right");

        public static InfixAssoc? From(string name)
        {
            return name switch
            {
                "non" => None,
                "left" => Left,
                "right" => Right,
                _ => null,
            };
        }

        public static readonly string KnownAssocs = "'non', 'left' or 'right'";

        public override string ToString() => Name;
    }
}
