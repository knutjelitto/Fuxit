using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    public static class FormatHelpers
    {
        public static string Join(this IReadOnlyList<Node> nodes, string joiner)
        {
            if (nodes.Count == 0)
            {
                return "";
            }

            return $"{joiner}{string.Join(joiner, nodes)}";
        }

        public static string SpaceJoin(this IReadOnlyList<Node> nodes)
        {
            return nodes.Join(" ");
        }

        public static string OptJoin(this Node left, string joiner, Node? right)
        {
            if (right == null)
            {
                return $"{left}";
            }
            return $"{left}{joiner}{right}";
        }
    }
}
