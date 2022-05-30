using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class OpChain : Expression
    {
        public OpChain(Expression first, IReadOnlyList<OpExpr> rest)
        {
            First = first;
            Rest = rest;
        }

        public Expression First { get; }
        public IReadOnlyList<OpExpr> Rest { get; }

        public override bool IsAtomic => throw new NotImplementedException();

        public Expression Resolve()
        {
            return Resolve(First, 0, Rest.ToList());
        }

        private Expression Resolve(Expression lhs, int minPrecedence, List<OpExpr> Rest)
        {
            var lookahead = Rest[0].Op;
            var lh_prec = Infix.Instance[lookahead.Text];

            while (Rest.Count > 0 && lh_prec.Precedence >= minPrecedence)
            {
                var op = lookahead;
                var op_prec = lh_prec;

                var rhs = Rest[0].Expression;

                Rest.RemoveAt(0);

                if (Rest.Count > 0)
                {
                    lookahead = Rest[0].Op;
                    lh_prec = Infix.Instance[lookahead.Text];

                    while (lh_prec.Precedence > op_prec.Precedence || lh_prec.Assoc == Infix.Assoc.Right && lh_prec.Precedence == op_prec.Precedence)
                    {
                        var prec = op_prec.Precedence + (lh_prec.Precedence > op_prec.Precedence ? 1 : 0);
                        rhs = Resolve(rhs, prec, Rest);

                        if (Rest.Count == 0)
                        {
                            break;
                        }

                        lookahead = Rest[0].Op;
                        lh_prec = Infix.Instance[lookahead.Text];
                    }
                }
                lhs = op.Combine(lhs, rhs);
            }

            return lhs;
        }

        public override string ToString()
        {
            return $"(chain {First} {string.Join(" ", Rest)})";
        }
    }
}
