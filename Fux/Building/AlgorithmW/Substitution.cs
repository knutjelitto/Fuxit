using System.Collections.Immutable;

namespace Fux.Building.AlgorithmW
{
    public class Substitution
    {
        private readonly ImmutableDictionary<TypeVar, WType> map;

        public static Substitution Empty() => new(ImmutableDictionary<TypeVar, WType>.Empty);

        public Substitution(ImmutableDictionary<TypeVar, WType> map) => this.map = map;

        public WType? TryGet(TypeVar typeVar) => map.TryGetValue(typeVar, out var type) ? type : null;

        public Substitution Insert(TypeVar typeVar, WType type) => new(map.Add(typeVar, type));

        public Substitution Remove(TypeVar typeVar) => new(map.Remove(typeVar));

        public IEnumerable<KeyValuePair<TypeVar, WType>> Enumerate() => map;

        public Substitution UnionWith(Substitution other)
        {
            var union = map;
            foreach (var kv in other.map)
            {
                if (!map.ContainsKey(kv.Key))
                {
                    union = union.Add(kv.Key, kv.Value);
                }
            }
            return new Substitution(union);
        }

        public override string ToString()
        {
            if (map.Count == 0)
            {
                return $"Substitution.Empty";
            }
            return $"Substitution[{map.Count}]";
        }
    }

}
