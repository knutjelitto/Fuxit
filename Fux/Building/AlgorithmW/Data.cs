using System.Collections.Immutable;

namespace Fux.Building.AlgorithmW
{
    /// <summary>
    /// A term variable is a variable referenced in an expression
    /// </summary>
    public record TermVar(string Name)
    {
        public static implicit operator string(TermVar term) => term.Name;
        public static implicit operator TermVar(string s) => new(s);
        public override string ToString() => Name;
    }

    public record TypeVar(int ID)
    {
        public override string ToString() => $"'t{ID}";
    }

    public class Polytype
    {
        public Polytype(IReadOnlyList<TypeVar> typeVariables, WType type)
        {
            TypeVariables = typeVariables;
            Type = type;
        }

        public Polytype(WType type)
            : this(Array.Empty<TypeVar>(), type)
        {
        }

        public IReadOnlyList<TypeVar> TypeVariables { get; }
        public WType Type { get; }
    }

    public class TypeEnvironment
    {
        private readonly ImmutableDictionary<TermVar, Polytype> map;

        private TypeEnvironment(ImmutableDictionary<TermVar, Polytype> map)
        {
            this.map = map;
        }

        public TypeEnvironment(IEnumerable<(TermVar var, Polytype poly)> values)
            : this(values.ToImmutableDictionary(kv => kv.var, kv => kv.poly))
        {
        }

        public static TypeEnvironment Empty() => new(ImmutableDictionary<TermVar, Polytype>.Empty);

        public Polytype? TryGet(TermVar term) => map.TryGetValue(term, out var polytype) ? polytype : null;
    
        public TypeEnvironment Insert(TermVar typeVar, Polytype polytype) => new(map.Add(typeVar, polytype));
        
        public TypeEnvironment Remove(TermVar term) => new(map.Remove(term));

        public IEnumerable<Polytype> Polytypes => map.Values;

        public IEnumerable<(TermVar var, Polytype polytype)> Enumerate() => map.Select(kv => (kv.Key, kv.Value));
    }
}
