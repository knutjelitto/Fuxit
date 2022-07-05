namespace Fux.Building.AlgorithmW
{
    /// <summary>
    /// A term variable is a variable referenced in an expression
    /// </summary>
    public sealed class TermVariable : IEquatable<TermVariable>
    {
        public TermVariable(string name)
        {
            Name = name;
        }

        public TermVariable(A.Identifier name)
        {
            Name = name.Text;
        }

        public string Name { get; }

        public static implicit operator string(TermVariable term) => term.Name;
        public static implicit operator TermVariable(string s) => new(s);

        public bool Equals(TermVariable? other) => other != null && other.Name == Name;
        public override bool Equals(object? obj) => Equals(obj as TermVariable);
        public override int GetHashCode() => Name.GetHashCode();
        public override string ToString() => Name;
    }
}
