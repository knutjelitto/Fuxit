using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Tools;

namespace Fux.Input.Ast
{
    public sealed class FieldDefine : Field
    {
        public FieldDefine(Identifier name, Type type)
        {
            Name = name;
            TypeDef = type;
        }

        public Identifier Name { get; }
        public Type TypeDef { get; }

        public override string ToString()
        {
            return $"{Name} : {TypeDef}";
        }

        public override void PP(Writer writer)
        {
            writer.Write($"{Name} : {TypeDef}");
        }
    }
}
