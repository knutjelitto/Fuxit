namespace Fux.Input.Ast
{
    internal class TypeDecl : Declaration
    {
        public TypeDecl(Identifier name, TypeParameters parameters, Constructors constructors)
            : base(name)
        {
            Parameters = parameters;
            Constructors = constructors;
        }

        public TypeParameters Parameters { get; }
        public Constructors Constructors { get; }

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
    }

}
