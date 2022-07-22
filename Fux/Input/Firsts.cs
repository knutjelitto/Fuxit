using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input
{
    public static class Firsts
    {
        public static readonly LexSet AtomExpr = LexSet.Empty.Add(
            Lex.LowerId, Lex.UpperId, Lex.OperatorId, Lex.Integer, Lex.Float, Lex.Char,
            Lex.String, Lex.LongString, Lex.LeftRoundBracket, Lex.LeftCurlyBracket,
            Lex.LeftSquareBracket, Lex.Lambda, Lex.Dot);

        public static readonly LexSet CompoundExpr = LexSet.Empty
            .Add(Lex.KwIf, Lex.KwLet, Lex.KwCase)
            .Add(AtomExpr);
    }
}
