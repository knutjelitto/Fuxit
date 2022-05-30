using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.ElmPackages
{
    internal class ExposedGroup : IReadOnlyList<ExposedModule>
    {
        private readonly List<ExposedModule> modules = new();

        public ExposedGroup(string name, IEnumerable<ExposedModule> modules)
        {
            Name = name;
            this.modules = modules.ToList();
        }

        public string Name { get; }

        public void Add(ExposedModule module)
        {
            modules.Add(module);
        }

        public ExposedModule this[int index] => modules[index];
        public int Count => modules.Count;

        public IEnumerator<ExposedModule> GetEnumerator() => modules.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
