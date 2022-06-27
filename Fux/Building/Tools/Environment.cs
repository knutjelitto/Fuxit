using System.Collections.Immutable;

using W = Fux.Building.AlgorithmW;

namespace Fux.Building.Tools
{
    internal class Environment
    {
        private readonly Dictionary<W.TermVariable, W.Polytype> builder = new();
    }
}
