namespace Fux.Input.Ast
{
    internal class ModuleDecl : Declaration
    {
        public ModuleDecl(Identifier name, bool isEffect, RecordExpression? where, Exposing? exposing)
            : base(name)
        {
            IsEffect = isEffect;
            Where = where;
            Exposing = exposing;
        }

        public bool IsEffect { get; }
        public RecordExpression? Where { get; }
        public Exposing? Exposing { get; }

        public override string ToString()
        {
            var effect = IsEffect ? "effect " : "";
            var where = Where != null ? $" where {Where}" : "";
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
            if (Where != null)
            {
                writer.Write($" where {Where}");
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
