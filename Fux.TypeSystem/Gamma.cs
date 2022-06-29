using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.TypeSystem.Abstract;

namespace Fux.TypeSystem
{
    public sealed class Gamma : WithFree
    {
        private readonly ImmutableDictionary<ExprVariable, Poly> map;
        public static readonly Gamma Empty = new Gamma(ImmutableDictionary<ExprVariable, Poly>.Empty);

        private Gamma(ImmutableDictionary<ExprVariable, Poly> map)
        {
            this.map = map;
        }

        public Gamma Add(ExprVariable variable, Poly type)
        {
            return new Gamma(map.Add(variable, type));
        }

        public ISet<MonoVariable> free()
        {
            var free = new HashSet<MonoVariable>();

            foreach (var poly in map.Values)
            {
                free.UnionWith(poly.free());
            }

            return free;
        }
    }
}
