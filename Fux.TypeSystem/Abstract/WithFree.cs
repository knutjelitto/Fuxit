using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable IDE1006 // Naming Styles

namespace Fux.TypeSystem.Abstract
{
    public interface WithFree
    {
        ISet<MonoVariable> free();
    }
}
