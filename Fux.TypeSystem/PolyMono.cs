using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.TypeSystem.Abstract;

namespace Fux.TypeSystem
{
    public sealed class PolyMono : Poly, IEquatable<PolyMono>
    {
        public PolyMono(Mono τ)
        {
            this.τ = τ;
        }

        public Mono τ { get; }
        public override ISet<MonoVariable> free() => τ.free();

        public bool Equals(PolyMono? other) => other != null && τ.Equals(other.τ);
        public override bool Equals(object? obj) => Equals(obj as PolyMono);
        public override int GetHashCode() => τ.GetHashCode();

    }
}
