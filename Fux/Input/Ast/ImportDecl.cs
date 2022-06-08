﻿namespace Fux.Input.Ast
{
    internal class ImportDecl : Declaration
    {
        public ImportDecl(Identifier name, Identifier? alias, Exposing? exposing)
            : base(name)
        {
            Alias = alias;
            Exposing = exposing;
        }

        public Exposing? Exposing { get; }

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