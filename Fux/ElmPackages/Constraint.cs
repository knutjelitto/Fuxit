using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Semver;

namespace Fux.ElmPackages
{
    internal class Constraint
    {
        public Constraint(SemVersion min, bool inclMin, SemVersion max, bool inclMax)
        {
            Min = min;
            InclMin = inclMin;
            Max = max;
            InclMax = inclMax;
        }

        public Constraint(SemVersion version)
            : this(version, true, version, true)
        {
        }

        public SemVersion Min { get; }
        public bool InclMin { get; }
        public SemVersion Max { get; }
        public bool InclMax { get; }

        public bool Match(SemVersion version)
        {
            bool min = InclMin ? Min <= version : Min < version;
            bool max = InclMax ? version <= Max : Max < version;

            return min && max;
        }

        public static Constraint Parse(string constraint)
        {
            var parts = constraint.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            Assert(parts.Length == 1 || parts.Length == 5);

            if (parts.Length == 1)
            {
                return new Constraint(SemVersion.Parse(parts[0], SemVersionStyles.Strict));
            }
            else if (parts.Length == 5)
            {
                var min = SemVersion.Parse(parts[0], SemVersionStyles.Strict);
                Assert(parts[1] == "<" || parts[1] == "<=");
                var includeMin = parts[1] == "<=";
                Assert(parts[2] == "v");
                Assert(parts[3] == "<" || parts[3] == "<=");
                var includeMax = parts[1] == "<=";
                var max = SemVersion.Parse(parts[4], SemVersionStyles.Strict);

                return new Constraint(min, includeMin, max, includeMax);
            }
            else
            {
                Assert(false);
            }

            throw new InvalidOperationException();
        }
    }
}
