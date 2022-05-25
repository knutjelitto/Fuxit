namespace Fux.Input
{
    internal class OpenToken : Token
    {
        public OpenToken(Token template)
            : base(Lex.GroupOpen, new Location(template.Location.Source, template.Location.Next, 0))
        {
        }

        public override string ToString()
        {
            return Lex.ToString();
        }
    }
}
