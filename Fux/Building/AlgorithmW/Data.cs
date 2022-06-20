using System.Collections.Immutable;

namespace Fux.Building.AlgorithmW
{
    /// <summary>
    /// A term variable is a variable referenced in an expression
    /// </summary>
    public sealed class TermVar
    {
        public TermVar(string name)
        {
            Name = name;
        }

        public string Name { get; }


        public static implicit operator string(TermVar term) => term.Name;
        public static implicit operator TermVar(string s) => new(s);

        public override string ToString() => Name;
        public override bool Equals(object? obj) => obj is TermVar other && other.Name == Name;
        public override int GetHashCode() => Name.GetHashCode();
    }

    public sealed class TypeVar
    {
        public TypeVar(int id)
        {
            ID = id;
        }

        public int ID { get; }

        public override string ToString() => $"'t{ID}";
        public override bool Equals(object? obj) => obj is TypeVar other && other.ID == ID;
        public override int GetHashCode() => ID.GetHashCode();
    }
}
