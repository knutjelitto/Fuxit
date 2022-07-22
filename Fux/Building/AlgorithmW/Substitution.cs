using System.Collections.Immutable;

namespace Fux.Building.AlgorithmW
{
    public sealed class Substitution
    {
        private readonly ImmutableDictionary<TypeVariable, Type> map;

        public static Substitution Empty() => new(ImmutableDictionary<TypeVariable, Type>.Empty);

        public static Substitution Solo(TypeVariable variable, Type type) => new(variable, type);

        public Substitution(ImmutableDictionary<TypeVariable, Type> map) => this.map = map;

        private Substitution(TypeVariable variable, Type type)
            : this(ImmutableDictionary.Create<TypeVariable, Type>().Add(variable, type))
        {
        }

        public Type? TryGet(TypeVariable typeVar) => map.TryGetValue(typeVar, out var type) ? type : null;

        public Substitution Insert(TypeVariable typeVar, Type type) => new(map.Add(typeVar, type));

        public Substitution Remove(TypeVariable typeVar) => new(map.Remove(typeVar));

        public Substitution RemoveRange(IEnumerable<TypeVariable> typeVars) => new(map.RemoveRange(typeVars));

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

        public Substitution UnionWith(IEnumerable<(TypeVariable, Type)> pairs)
        {
            var union = map;
            foreach (var (variable, type) in pairs)
            {
                if (!map.ContainsKey(variable))
                {
                    union = union.Add(variable, type);
                }
            }
            return new Substitution(union);
        }

        public override string ToString()
        {
            return $"Substitution{{{string.Join(", ", Enumerate().Select(kv => str(kv)))}}}";

            string str(KeyValuePair<TypeVariable, Type> kv)
            {
                return $"{kv.Key}->{kv.Value}";
            }
        }
    }

}
