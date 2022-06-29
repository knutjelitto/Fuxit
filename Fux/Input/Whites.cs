namespace Fux.Input
{
    public sealed class Whites : List<Token>
    {
        public override string ToString()
        {
            return string.Join("", this);
        }
    }
}
