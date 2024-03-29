﻿using Semver;

namespace Fux.ElmPackages
{
    public sealed class Constraint
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
            bool min = InclMin ? Min.ComparePrecedenceTo(version) <= 0 : Min.ComparePrecedenceTo(version) < 0;
            bool max = InclMax ? version.ComparePrecedenceTo(Max) <= 0 : version.ComparePrecedenceTo(Max) < 0;

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
                var includeMax = parts[3] == "<=";
                var max = SemVersion.Parse(parts[4], SemVersionStyles.Strict);

                return new Constraint(min, includeMin, max, includeMax);
            }
            else
            {
                Assert(false);
            }

            throw new InvalidOperationException();
        }

        public override string ToString()
        {
            if (Min == Max && InclMin && InclMax)
            {
                return $"{Min}";
            }

            var lower = InclMin ? "<=" : "<";
            var upper = InclMax ? "<=" : "<";
            return $"{Min} {lower} v {upper} {Max}";
        }
    }
}
