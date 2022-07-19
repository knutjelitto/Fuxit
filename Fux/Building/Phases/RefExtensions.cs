using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Building.Phases
{
    public static class RefExtensions
    {
        public static T Locate<T>(this T r, A.Expr d)
            where T : A.Expr.Ref
        {
            //Assert(d.InModule != null);
            //Assert(d.Span != null);

            r.InModule = d.InModule;
            r.Span = d.Span;

            return r;
        }
    }
}
