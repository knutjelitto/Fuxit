using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.TypeSystem.Abstract;

namespace Fux.TypeSystem
{
    public sealed class MonoApplication : Mono, IEquatable<MonoApplication>
    {
        public MonoApplication(Ident C, params Mono[] τ)
        {
            this.C = C;
            this.τ = τ;
        }

        public Ident C { get; }
        public Mono[] τ { get; }

        public override ISet<MonoVariable> free()
        {
            var free = new HashSet<MonoVariable>();
            foreach (var mono in τ)
            {
                free.UnionWith(mono.free());
            }
            return free;
        }

        public bool Equals(MonoApplication? other) => other != null && C.Equals(other.C) && τ.SequenceEqual(other.τ);
        public override bool Equals(object? obj) => Equals(obj as MonoApplication);
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(C);
            foreach (var mono in τ)
            {
                hash.Add(mono);
            }
            return hash.ToHashCode();
        }
    }
}
