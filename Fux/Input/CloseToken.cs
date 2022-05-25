namespace Fux.Input
{
    internal class CloseToken : Token
    {
        public CloseToken(Token template)
            : base(Lex.GroupClose, new Location(template.Location.Source, template.Location.Next, 0))
        {
        }

        public override string ToString()
        {
            return Lex.ToString();
        }
    }
}
