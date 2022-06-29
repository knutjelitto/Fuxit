using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.TypeSystem.Abstract
{
    public abstract class Poly : Type, WithFree
    {
        public abstract ISet<MonoVariable> free();
    }
}
