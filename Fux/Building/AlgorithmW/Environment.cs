using System.Collections.Immutable;

namespace Fux.Building.AlgorithmW
{
    public sealed class Environment
    {
        public readonly TypeVarGenerator Generator;

        private readonly ImmutableDictionary<TermVariable, Polytype> Map;

        private Environment(TypeVarGenerator generator, ImmutableDictionary<TermVariable, Polytype> map)
        {
            Generator = generator;
            Map = map;
        }

        public Environment(TypeVarGenerator generator, IEnumerable<(TermVariable var, Polytype poly)> values)
            : this(generator, values.ToImmutableDictionary(kv => kv.var, kv => kv.poly))
        {
        }

        public static Environment From(Environment env, IEnumerable<(TermVariable var, Polytype poly)> values)
        {
            return new Environment(env.Generator, values);
        }

        public static Environment Initial(TypeVarGenerator generator, params (TermVariable var, Polytype polytype)[] inits)
        {
            var builder = ImmutableDictionary.CreateBuilder<TermVariable, Polytype>();

            foreach (var (var, polytype) in inits)
            {
                builder.Add(var, polytype);
            }

            return new(generator, builder.ToImmutable());
        }

        public static Environment Empty()
        {
            return Initial(new TypeVarGenerator());
        }

        public Environment NewEmpty()
        {
            return Initial(Generator);
        }

        public Polytype? TryGet(TermVariable term) => Map.TryGetValue(term, out var polytype) ? polytype : null;

        public Environment Insert(TermVariable term, Polytype polytype) => new(Generator, Map.Add(term, polytype));

        public Environment Remove(TermVariable term) => new(Generator, Map.Remove(term));

        public IEnumerable<Polytype> Polytypes => Map.Values;

        public IEnumerable<(TermVariable var, Polytype polytype)> Enumerate() => Map.Select(kv => (kv.Key, kv.Value));

        public Type.Variable GetNextTypeVar(string? name = null) => Generator.GetNextTypeVar(name);
    }
}
