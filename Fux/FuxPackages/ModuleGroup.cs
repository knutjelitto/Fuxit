using System.Collections;

namespace Fux.FuxPackages
{
    public sealed class ModuleGroup : IReadOnlyList<Module>
    {
        private readonly List<Module> modules = new();

        public ModuleGroup(string name, IEnumerable<Module> modules)
        {
            Name = name;
            this.modules = modules.ToList();
        }

        public string Name { get; }

        public void Add(Module module)
        {
            modules.Add(module);
        }

        public Module this[int index] => modules[index];
        public int Count => modules.Count;

        public IEnumerator<Module> GetEnumerator() => modules.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
