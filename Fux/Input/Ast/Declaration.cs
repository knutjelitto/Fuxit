﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Input.Ast
{
    internal abstract class Declaration : Expression
    {
        protected Declaration(Identifier name)
        {
            Name = name;
        }

        public Identifier Name { get; }
    }
}
