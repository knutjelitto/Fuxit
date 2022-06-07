using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    internal class ExposingAll : Exposing
    {
        public override void PP(Writer writer)
        {
            writer.Write($"{ToString()}");
        }

        public override string ToString()
        {
            return $"{Lex.Weak.Exposing} {Lex.Weak.ExposeAll}";
        }
    }
}
