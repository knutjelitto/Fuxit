using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Semver;

namespace Fux.ElmPackages
{
    internal class Dependency
    {
        public Dependency(string name, Constraint constraint)
        {
            Name = name;
            Constraint = constraint;
        }

        public string Name { get; }
        public Constraint Constraint { get; }

        public bool Match(SemVersion version)
        {
            return Constraint.Match(version);
        }
    }
}
