using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    [Flags]
    internal enum Lex
    {
        BOF,
        EOF,
        Newline,
        Space,
        LowerId,
        UpperId,
        Number,
        Operator,
        LParent,
        RParent,
        LBrace,
        RBrace,
        LBracket,
        RBracket,
    }
}
