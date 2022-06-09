namespace Fux.Input.Ast
{
    internal class ModuleDecl : Declaration
    {
        public ModuleDecl(Identifier name, bool isEffect, IEnumerable<VarDecl> where, Exposing? exposing)
            : base(name)
        {
            IsEffect = isEffect;
            Where = where.ToArray();
            Exposing = exposing;
        }

        public bool IsEffect { get; }
        public IReadOnlyList<VarDecl> Where { get; }
        public Exposing? Exposing { get; }

        public override string ToString()
        {
            var effect = IsEffect ? "effect " : "";
            var where = Where.Count > 0 ? $" where {{ {string.Join(", ", Where)} }}" : "";
            var exposing = Exposing == null ? "" : $" {Exposing}";
            return $"{effect}module {Name}{where}{exposing}";
        }

        public override void PP(Writer writer)
        {
            if (IsEffect)
            {
                writer.Write("effect ");
            }
            writer.Write($"module {Name}");
            if (Where.Count > 0)
            {
                writer.Write($" where {{ {string.Join(", ", Where)} }}");
            }
            if (Exposing != null)
            {
                writer.Write(" ");
                Exposing.PP(writer);
                if (writer.LinePending)
                {
                    writer.WriteLine();
                }
            }
        }
    }
}
