namespace Fux.Building.Typing
{
    public class IdGenerator
    {
        private readonly Dictionary<string, int> counters = new();

        public IdGenerator(Module module)
        {
            Module = module;
        }

        public Module Module { get; }

        public void Clear()
        {
            counters.Clear();
        }

        public A.Identifier For(string prefix)
        {
            if (!counters.TryGetValue(prefix, out int count))
            {
                count = 0;
                counters.Add(prefix, count);
            }
            count++;
            counters[prefix] = count;
            return A.Identifier.Artificial(Module, $"{prefix}_{count}");
        }
    }
}
