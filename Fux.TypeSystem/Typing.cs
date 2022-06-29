using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.TypeSystem.Abstract;

namespace Fux.TypeSystem
{
    public sealed class Typing : WithFree
    {
        public Typing(Gamma Γ, Expr e, Poly σ)
        {
            this.Γ = Γ;
            this.e = e;
            this.σ = σ;
        }

        public Gamma Γ { get; }
        public Expr e { get; }
        public Poly σ { get; }

        public ISet<MonoVariable> free()
        {
            var free = σ.free();

            free.ExceptWith(Γ.free());

            return free;
        }
    }
}
