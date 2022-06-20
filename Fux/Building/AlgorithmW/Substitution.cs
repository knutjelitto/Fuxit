using System.Collections.Immutable;

namespace Fux.Building.AlgorithmW
{
    internal sealed class Substitution
    {
        private readonly ImmutableDictionary<TypeVariable, Type> map;

        public static Substitution Empty() => new(ImmutableDictionary<TypeVariable, Type>.Empty);

        public Substitution(ImmutableDictionary<TypeVariable, Type> map) => this.map = map;

        public Type? TryGet(TypeVariable typeVar) => map.TryGetValue(typeVar, out var type) ? type : null;

        public Substitution Insert(TypeVariable typeVar, Type type) => new(map.Add(typeVar, type));

        public Substitution Remove(TypeVariable typeVar) => new(map.Remove(typeVar));

        public IEnumerable<KeyValuePair<TypeVariable, Type>> Enumerate() => map;

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
