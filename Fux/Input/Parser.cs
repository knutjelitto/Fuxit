namespace Fux.Input
{
    internal class Parser
    {
        public Parser(Layouter layouter)
        {
            Layouter = layouter;
        }

        public Layouter Layouter { get; }
    }
}
