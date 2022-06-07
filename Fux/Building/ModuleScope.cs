using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Building
{
    internal class ModuleScope : Scope
    {
        private readonly List<ImportDecl> imports = new();
        private readonly List<InfixDecl> infixes = new();
        private readonly Dictionary<string, InfixDecl> infixesIndex = new();
        private readonly Dictionary<string, TypeDecl> types = new();
        private readonly Dictionary<string, AliasDecl> aliases = new();

        public void Add(ImportDecl import)
        {
            imports.Add(import);
        }

        public void Add(InfixDecl decl)
        {
            var name = decl.Name.SingleOp();

            Assert(!infixesIndex.ContainsKey(name));

            infixes.Add(decl);
            infixesIndex.Add(name, decl);
        }

        public void Add(TypeDecl decl)
        {
            var name = decl.Name.SingleUpper();

            Assert(!types.ContainsKey(name));

            types.Add(name, decl);
        }

        public void Add(AliasDecl decl)
        {
            var name = decl.Name.SingleUpper();

            Assert(!aliases.ContainsKey(name));

            aliases.Add(name, decl);
        }
    }
}
