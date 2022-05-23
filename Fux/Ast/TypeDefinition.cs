using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class TypeDefinition : Expression
    {
        public TypeDefinition(Token type, Expression lhs, Token defineToken, Expression rhs)
        {
            TypeToken = type;
            Lhs = lhs;
            DefineToken = defineToken;
            Rhs = rhs;
        }

        public override bool IsAtomic => true;

        public Token TypeToken { get; }
        public Expression Lhs { get; }
        public Token DefineToken { get; }
        public Expression Rhs { get; }

        public override string ToString()
        {
            return $"{Lhs} {TypeToken} {Rhs}";
        }
    }
}
