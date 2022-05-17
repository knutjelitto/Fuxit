using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal enum Lex
    {
        Newline,
        Space,
        LowerId,
        UpperId,
        Number,
        Operator,
        LParent,
        RParent,
    }
}
