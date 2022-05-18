using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    internal static class TokenPredicate
    {
        public static bool IsOperator(this Token token)
        {
            return token.Lex == Lex.Operator;
        }

        public static bool IsLiteral(this Token token)
        {
            return token.Lex == Lex.Number;
        }
    }
}
