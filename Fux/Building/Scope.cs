using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Building
{
    internal class Scope
    {
        private readonly Dictionary<string, Declaration> declarations = new();
        private readonly Dictionary<string, TypeHint> hints = new();

        public Scope? Parent { get; set; }
        public bool HintEmpty => hints.Count == 0;

        public void Add(TypeHint hint)
        {
            var name = hint.Name.SingleLower();

            Assert(!hints.ContainsKey(name));
            
            hints.Add(name, hint);
        }

        public void Add(VarDecl decl)
        {
            var name = decl.Name.SingleLower();

            Assert(!declarations.ContainsKey(name));

            declarations.Add(name, decl);

            if (hints.TryGetValue(name, out var hint))
            {
                decl.Hint = hint;
                hints.Remove(name);
            }
        }
    }
}
