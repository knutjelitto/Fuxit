using Fux.Building;

namespace Fux.Input.Ast
{
    internal sealed class UnionDecl : Declaration
    {
        public UnionDecl(Identifier name, TypeParameters parameters, Constructors constructors)
            : base(name)
        {
            Parameters = parameters;
            Constructors = constructors;

            Type = new Type.UnionType(Name, parameters, constructors);
        }

        public TypeParameters Parameters { get; }
        public Constructors Constructors { get; }
        public TypeScope Scope { get; } = new();

        public Type.UnionType Type { get; }

        public override string ToString()
        {
            var parameters = Parameters.Count == 0 ? "" : $" {Parameters}";
            return $"{Lex.KwType} {Name}{parameters} = {Constructors}";
        }

        public override void PP(Writer writer)
        {
            var parameters = Parameters.Count > 0 ? $" {string.Join(' ', Parameters)}" : "";
            if (Constructors.Count == 1)
            {
                writer.WriteLine($"type {Name}{parameters} = {Constructors[0]}");
            }
            else
            {
                writer.WriteLine($"type {Name}{parameters}");
                writer.Indent(() =>
                {
                    var prefix = "= ";
                    foreach (var ctor in Constructors)
                    {
                        writer.Write(prefix);
                        prefix = "| ";
                        writer.WriteLine($"{ctor}");
                    }
                });
            }
        }
    }

    internal class Constructors : ListOf<Type.Constructor>
    {
        public Constructors(IEnumerable<Type.Constructor> items)
            : base(items)
        {
        }

        public Constructors(params Type.Constructor[] items)
            : this(items.AsEnumerable())
        {
        }

        public override string ToString()
        {
            return string.Join(" | ", this);
        }
    }

}
