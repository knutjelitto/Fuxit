using System.Collections;

namespace Fux.ElmPackages
{
    public sealed class ElmModuleGroup : IReadOnlyList<ElmModule>
    {
        private readonly List<ElmModule> modules = new();

        public ElmModuleGroup(string name, IEnumerable<ElmModule> modules)
        {
            Name = name;
            this.modules = modules.ToList();
        }

        public string Name { get; }

        public void Add(ElmModule module)
        {
            modules.Add(module);
        }

        public ElmModule this[int index] => modules[index];
        public int Count => modules.Count;

        public IEnumerator<ElmModule> GetEnumerator() => modules.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
