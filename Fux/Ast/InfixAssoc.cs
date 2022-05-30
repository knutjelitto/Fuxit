﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class InfixAssoc
    {
        private InfixAssoc(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static readonly InfixAssoc None = new InfixAssoc("non");
        public static readonly InfixAssoc Left = new InfixAssoc("left");
        public static readonly InfixAssoc Right = new InfixAssoc("right");

        public static InfixAssoc? From(string name)
        {
            return name switch
            {
                "non" => None,
                "left" => Left,
                "right" => Right,
                _ => null,
            };
        }

        public static readonly string KnownAssocs = "'non', 'left' or 'right'";

        public override string ToString() => Name;
    }
}
