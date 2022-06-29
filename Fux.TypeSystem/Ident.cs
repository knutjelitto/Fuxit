using System.Runtime.CompilerServices;

namespace Fux.TypeSystem
{
    public sealed class Ident : IEquatable<Ident>
    {
        private readonly int hash;
        public Ident(string text)
        {
            Text = String.Intern(text);
            hash = Text.GetHashCode();
        }

        public string Text { get; }

        public bool Equals(Ident? other) => other != null && ReferenceEquals(Text, other.Text);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object? obj) => Equals(obj as Ident);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => hash;
    }
}
