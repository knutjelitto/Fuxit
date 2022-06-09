using Fux.Building;

namespace Fux.Input.Ast
{
    internal class ImportDecl : Declaration
    {
        public ImportDecl(Identifier name, Identifier? alias, Exposing? exposing)
            : base(name)
        {
            Alias = alias;
            Exposing = exposing;

            if (name.ToString() == "Elm.Kernel.Basics")
            {
                Assert(true);
            }
        }

        public Exposing? Exposing { get; }

        public Module? Module { get; set; } 

        public override string ToString()
        {
            var alias = Alias == null ? "" : $" as {Alias}";
            var exposinf = Exposing == null ? "" : $" {Exposing}";

            return $"import {Name}{alias}{exposinf}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"import {Name}");
            if (Alias != null)
            {
                writer.Write($" alias {Alias}");
            }
            if (Exposing != null)
            {
                writer.Write($" {Exposing}");
            }
            writer.WriteLine();
        }
    }
}
