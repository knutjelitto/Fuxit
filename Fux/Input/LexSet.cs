namespace Fux.Input
{
    public class LexSet
    {
        private HashSet<Lex> lexes;

        public static LexSet Empty { get; } = new LexSet();

        private LexSet(IEnumerable<Lex> lexes)
        {
            this.lexes = new HashSet<Lex>(lexes);
        }

        private LexSet(params Lex[] lexes)
            : this(lexes.AsEnumerable())
        {
        }

        public LexSet Add(IEnumerable<Lex> lexes)
        {
            var newSet = new LexSet(this.lexes);
            foreach (var lex in lexes)
            {
                newSet.lexes.Add(lex);
            }
            return newSet;
        }

        public LexSet Add(params Lex[] lexes)
        {
            return Add(lexes.AsEnumerable());
        }

        public LexSet Add(LexSet lexes)
        {
            return Add(lexes.lexes);
        }
    }
}
