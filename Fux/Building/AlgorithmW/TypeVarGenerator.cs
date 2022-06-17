using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Building.AlgorithmW
{
    public class TypeVarGenerator
    {
        private int supply = 0;
        public VariableType GetNext() => new(new(supply++));
    }
}
