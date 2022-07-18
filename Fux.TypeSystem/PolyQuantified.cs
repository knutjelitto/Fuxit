using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.TypeSystem.Abstract;

namespace Fux.TypeSystem
{
    public sealed class PolyQuantified : Poly
    {
        public PolyQuantified(MonoVariable α, Poly σ)
        {
            this.α = α;
            this.σ = σ;
        }

        public MonoVariable α { get; }
        public Poly σ { get; }

        public override ISet<MonoVariable> free()
        {
            var free = σ.free();

            free.ExceptWith(α.free());

            return free;
        }
    }
}
