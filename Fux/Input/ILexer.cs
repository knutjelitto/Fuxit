using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    public interface ILexer : IEnumerable<Tokens>
    {
        ISource Source { get; }
        Tokens GetLine();
    }
}
