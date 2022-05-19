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
        LineComment,
        BlockComment,
        
        LowerId,
        UpperId,
        Operator,

        Number,
        String,

        Semicolon,
        Comma,
        
        LParent,
        RParent,
        LBrace,
        RBrace,
        LBracket,
        RBracket,
    }
}
