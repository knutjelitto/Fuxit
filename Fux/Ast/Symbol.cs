﻿using Fux.Input;

namespace Fux.Ast
{
    internal abstract class Symbol : Atom
    {
        public Symbol(Token token)
        {
            Token = token;
        }

        public Token Token { get; }

        public override void PP(Writer writer)
        {
            writer.Write($"{Token}");
        }
    }
}
