namespace Fux.Building.AlgorithmW
{
    /// <summary>
    /// A term variable is a variable referenced in an expression
    /// </summary>
    public sealed class TermVariable
    {
        public TermVariable(string name)
        {
            Name = name;
        }

        public string Name { get; }


        public static implicit operator string(TermVariable term) => term.Name;
        public static implicit operator TermVariable(string s) => new(s);

        public override string ToString() => Name;
        public override bool Equals(object? obj) => obj is TermVariable other && other.Name == Name;
        public override int GetHashCode() => Name.GetHashCode();
    }
}
