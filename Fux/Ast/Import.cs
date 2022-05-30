using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class Import : Expression
    {
        public Import(Expression path, Expression? alias, Expression? exposed)
        {
            Path = path;
            Alias = alias;
            Exposed = exposed;
        }

        public Expression Path { get; }
        public Expression? Alias { get; }
        public Expression? Exposed { get; }

        public override bool IsAtomic => false;

        public override string ToString()
        {
            var alias = Alias == null ? "" : $" as {Alias}";
            var exposed = Exposed == null ? "" : $" exposing {Exposed}";

            return $"import {Path}{alias}{exposed}";
        }
    }
}
