using Fux.Building;

namespace Fux.Input.Ast
{
    public interface NamedDecl : Decl
    {
        Identifier Name { get; }
        Identifier? Alias { get; set; }

    }

    public interface Decl : Node
    {
        public abstract class DeclImpl : NodeImpl, Decl
        {
        }

        public abstract class NamedDeclImpl : NodeImpl, NamedDecl
        {
            protected NamedDeclImpl(Identifier name)
            {
                Name = name;
            }

            public Identifier Name { get; }
            public Identifier? Alias { get; set; }
        }
    }

    public sealed class ModuleDecl : Decl.NamedDeclImpl
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

    public sealed class VarDecl : Decl.NamedDeclImpl
    {
        public VarDecl(Identifier name, Parameters parameters, Expr expression)
            : base(name)
        {
            Parameters = parameters;
            Expression = expression;

            Collector.Instance.VarPattern.Add(parameters);
        }

        public Parameters Parameters { get; }
        public Expr Expression { get; }
        public Type? Type { get; set; }

        public VarScope Scope { get; } = new VarScope();

        public override string ToString()
        {
            var parameters = Parameters.Count == 0 ? "" : $" {string.Join(' ', Parameters)}";
            return $"{Name}{parameters} {Lex.Assign} {Expression}";
        }

        public override void PP(Writer writer)
        {
            var parameters = Parameters.Count == 0 ? "" : $" {string.Join(' ', Parameters)}";
            writer.Write($"{Name}{parameters} {Lex.Assign}");
            if (writer.Indentation == 0)
            {
                writer.WriteLine();
                writer.Indent(() =>
                {
                    Expression.PP(writer);
                });
            }
            else
            {
                writer.Write(" ");
                Expression.PP(writer);
            }
        }
    }

    public sealed class TypeDecl : Decl.NamedDeclImpl
    {
        public TypeDecl(Identifier name, TypeParameterList parameters, ConstructorList constructors)
            : base(name)
        {
            Parameters = parameters;
            Constructors = constructors;

            Type = new Type.UnionType(Name, parameters, constructors);
        }

        public TypeParameterList Parameters { get; }
        public ConstructorList Constructors { get; }
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

    public sealed class AliasDecl : Decl.NamedDeclImpl
    {
        public AliasDecl(Identifier name, TypeParameterList parameters, Type declaration)
            : base(name)
        {
            Parameters = parameters;
            Declaration = declaration;
        }
        public TypeParameterList Parameters { get; }
        public Type Declaration { get; }

        public override string ToString()
        {
            var parameters = Parameters.Count > 0 ? $" {string.Join(' ', Parameters)}" : "";
            return $"type alias {Name}{parameters} = {Declaration}";
        }

        public override void PP(Writer writer)
        {
            writer.WriteLine($"{this}");
        }
    }

    public sealed class ImportDecl : Decl.NamedDeclImpl
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
            var exposing = Exposing == null ? "" : $" {Exposing}";

            return $"import {Name}{alias}{exposing}";
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

    public sealed class InfixDecl : Decl.NamedDeclImpl
    {
        public InfixDecl(InfixAssoc assoc, InfixPower power, Identifier op, Identifier expression)
            : base(op)
        {
            Assoc = assoc;
            Precedence = power;
            Expression = expression;
        }

        public InfixAssoc Assoc { get; }
        public InfixPower Precedence { get; }
        public Identifier Expression { get; }
        public int Power => Precedence.Value;

        public override string ToString()
        {
            return $"infix {Assoc} {Precedence} {Name} = {Expression}";
        }

        public override void PP(Writer writer)
        {
            writer.WriteLine($"{this}");
        }
    }

    public sealed class NativeDecl : Decl.DeclImpl
    {
        public NativeDecl(Identifier moduleName, Identifier name)
        {
            ModuleName = moduleName;
            Name = name;
        }

        public Identifier ModuleName { get; }
        public Identifier Name { get; }
        public Type? Type { get; set; } = null;

        public override string ToString()
        {
            return $"{ModuleName}.{Name}";
        }

        public override void PP(Writer writer)
        {
            var type = Type == null ? "<???>" : $"{Type}";
            writer.Write($"{ModuleName}.{Name} : {type}");
        }
    }
    public sealed class TypeAnnotation : Decl.NamedDeclImpl
    {
        public TypeAnnotation(Identifier name, Type type)
            : base(name.SingleLower())
        {

            Type = type;
        }

        public Type Type { get; }

        public override string ToString()
        {
            return Protected($"{Name} {Lex.Colon} {Type}");
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Name} {Lex.Colon} ");
            Type.PP(writer);
        }
    }

    public sealed class Constructor : Decl.NamedDeclImpl
    {
        public Constructor(Identifier name, TypeArgumentList arguments)
            : base(name)
        {
            Assert(name.IsMultiUpper);

            Arguments = arguments;
        }
        public TypeArgumentList Arguments { get; }

        public override void PP(Writer writer)
        {
            writer.Write(ToString());
        }

        public override string ToString()
        {
            if (Arguments.Count == 0)
            {
                return Protected($"{Name}");
            }
            return Protected($"{Name} {Arguments}");
        }
    }


    public sealed class TypeParameter : Decl.NamedDeclImpl
    {
        public TypeParameter(Identifier name)
            : base(name.SingleLower())
        {
        }

        public string Text => Name.Text;

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
