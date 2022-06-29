using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.TypeSystem.Abstract;

#pragma warning disable IDE1006 // Naming Styles

namespace Fux.TypeSystem
{
    public sealed class MonoVariable : Mono, IEquatable<MonoVariable>
    {
        public MonoVariable(Ident id)
        {
            this.id = id;
        }

        public Ident id { get; }

        public override ISet<MonoVariable> free() => new HashSet<MonoVariable> { this };

        public bool Equals(MonoVariable? other) => other != null && id.Equals(other.id);
        public override bool Equals(object? obj) => Equals(obj as MonoVariable);
        public override int GetHashCode() => id.GetHashCode();
    }
}
