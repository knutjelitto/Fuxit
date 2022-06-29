using System.Collections;

namespace Fux.ElmPackages
{
    public sealed class Dependencies : IReadOnlyList<Dependency>
    {
        private readonly List<Dependency> dependencies = new();

        public void Add(Dependency dependency)
        {
            dependencies.Add(dependency);
        }

        public Dependency this[int index] => dependencies[index];
        public int Count => dependencies.Count;
        public IEnumerator<Dependency> GetEnumerator() => dependencies.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
