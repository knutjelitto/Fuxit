using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal abstract class Source
    {
        public abstract bool EOS { get; }
        public abstract bool GetNext(out char rune);
    }
}
