using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class LexExpression : Expression
    {
        public LexExpression(Token letToken, IReadOnlyList<Expression>  declarations, Token inToken, Expression expression)
        {
            LetToken = letToken;
            Declarations = declarations;
            InToken = inToken;
            Expression = expression;
        }

        public Token LetToken { get; }
        public IReadOnlyList<Expression> Declarations { get; }
        public Token InToken { get; }
        public Expression Expression { get; }
            public override bool IsAtomic => false;
    }
}
