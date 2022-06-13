namespace Fux.Input.Ast
{
    internal class OpChain : Expression
    {
        public OpChain(Expression first, IEnumerable<OpExpr> rest)
        {
            First = first;
            Rest = rest.ToArray();
        }

        public Expression First { get; }
        public IReadOnlyList<OpExpr> Rest { get; }

        public Expression Resolve()
        {
            return Resolve(First, 0, Rest.ToList());
        }

        private Expression Resolve(Expression lhs, int minPower, List<OpExpr> Rest)
        {
            var lhop = Rest[0].Op;
            var lh = (InfixDecl)lhop.Resolved!;

            while (Rest.Count > 0 && lh.Power >= minPower)
            {
                var opop = lhop;
                var op = lh;

                var rhs = Rest[0].Expression;

                Rest.RemoveAt(0);

                if (Rest.Count > 0)
                {
                    lhop = Rest[0].Op;
                    lh = (InfixDecl)lhop.Resolved!;

                    while (lh.Power > op.Power || lh.Assoc == InfixAssoc.Right && lh.Power == op.Power)
                    {
                        var prec = op.Power + (lh.Power > op.Power ? 1 : 0);
                        rhs = Resolve(rhs, prec, Rest);

                        if (Rest.Count == 0)
                        {
                            break;
                        }

                        lh = (InfixDecl)Rest[0].Op.Resolved!;
                    }
                }
                Assert(lhs.Resolved != null && rhs.Resolved != null);
                lhs = opop.Combine(lhs.Resolved, rhs.Resolved);
                lhs.Resolved = lhs;
            }

            return lhs;
        }

        public override string ToString()
        {
            return $"(chain {First} {string.Join(" ", Rest)})";
        }

        public override void PP(Writer writer)
        {
            writer.Write(ToString());
        }
    }
}
