using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class InfixDefinition : Expression
    {
        public InfixDefinition(InfixAssoc assoc, InfixPower power, Identifier op, Expression implementation)
        {
            Assoc = assoc;
            Power = power;
            Op = op;
            Implementation = implementation;
        }

        public override bool IsAtomic => false;

        public InfixAssoc Assoc { get; }
        public InfixPower Power { get; }
        public Identifier Op { get; }
        public Expression Implementation { get; }

        public override string ToString()
        {
            return $"infix {Assoc} {Power} {Op} = {Implementation}";
        }

        public override void PP(Writer writer)
        {
            writer.WriteLine($"{this}");
        }
    }
}
