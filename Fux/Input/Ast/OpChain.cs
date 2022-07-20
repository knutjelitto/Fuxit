namespace Fux.Input.Ast
{
    public sealed class OpChain : Expr.ExprImpl
    {
        public static int OpChains = 0;
        public static int ResolvedOpChains = 0;

        public OpChain(Expr first, IEnumerable<OpExpr> rest)
        {
            First = first;
            Rest = rest.ToList();

            OpChains++;
        }

        public Expr First { get; set; }
        public List<OpExpr> Rest { get; }

        public Expr Resolve()
        {
            Assert(Resolved == this);

            var resolved = Resolve(First, 0, Rest.ToList());

            this.Resolved = resolved;

            return resolved;
        }

        private Expr Resolve(Expr lhs, int minPower, List<OpExpr> Rest)
        {
            var lhop = Rest[0].Op;
            var lh = lhop.InfixDecl!;

            while (Rest.Count > 0 && lh.Power >= minPower)
            {
                var opop = lhop;
                var op = lh;

                var rhs = Rest[0].Expression;

                Rest.RemoveAt(0);

                if (Rest.Count > 0)
                {
                    lhop = Rest[0].Op;
                    lh = lhop.InfixDecl!;

                    while (lh.Power > op.Power || lh.Assoc == InfixAssoc.Right && lh.Power == op.Power)
                    {
                        var prec = op.Power + (lh.Power > op.Power ? 1 : 0);
                        rhs = Resolve(rhs, prec, Rest);

                        if (Rest.Count == 0)
                        {
                            break;
                        }

                        lh = Rest[0].Op.InfixDecl!;
                    }
                }
                Assert(lhs.Resolved is Expr && rhs.Resolved is Expr);
                lhs = opop.Combine((Expr)lhs.Resolved, (Expr)rhs.Resolved);
                lhs.Resolved = lhs;

                ResolvedOpChains++;
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
