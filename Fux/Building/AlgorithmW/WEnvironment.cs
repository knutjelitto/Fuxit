using System.Collections.Immutable;

namespace Fux.Building.AlgorithmW
{
    public class WEnvironment
    {
        private readonly ImmutableDictionary<TermVar, Polytype> map;

        private WEnvironment(ImmutableDictionary<TermVar, Polytype> map)
        {
            this.map = map;
        }

        public WEnvironment(IEnumerable<(TermVar var, Polytype poly)> values)
            : this(values.ToImmutableDictionary(kv => kv.var, kv => kv.poly))
        {
        }

        public static WEnvironment Empty() => new(ImmutableDictionary<TermVar, Polytype>.Empty);

        public static WEnvironment Initial(params (TermVar var, Polytype polytype)[] inits)
        {
            var builder = ImmutableDictionary.CreateBuilder<TermVar, Polytype>();

            foreach (var init in inits)
            {
                builder.Add(init.var, init.polytype);
            }

            return new(builder.ToImmutable());
        }

        public Polytype? TryGet(TermVar term) => map.TryGetValue(term, out var polytype) ? polytype : null;

        public WEnvironment Insert(TermVar typeVar, Polytype polytype) => new(map.Add(typeVar, polytype));

        public WEnvironment Remove(TermVar term) => new(map.Remove(term));

        public IEnumerable<Polytype> Polytypes => map.Values;

        public IEnumerable<(TermVar var, Polytype polytype)> Enumerate() => map.Select(kv => (kv.Key, kv.Value));
    }
}
