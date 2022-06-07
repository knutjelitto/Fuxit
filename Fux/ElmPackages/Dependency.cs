using Semver;

namespace Fux.ElmPackages
{
    internal class Dependency
    {
        public Dependency(string name, Constraint constraint)
        {
            if (name.Contains('.'))
            {
                Assert(false);
            }
            Name = name;
            Constraint = constraint;
        }

        public string Name { get; }
        public Constraint Constraint { get; }

        public bool Match(SemVersion version)
        {
            return Constraint.Match(version);
        }

        public override string ToString()
        {
            return $"{Name}({Constraint})";
        }
    }
}
