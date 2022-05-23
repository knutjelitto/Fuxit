using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Fux.Input;

namespace Fux.Ast
{
    internal class Infix
    {
        public static readonly Infix Instance = new Infix();

        private readonly Dictionary<string,Prec> precs = new();

        private Infix()
        {
            Add("=", 10, Assoc.None);
            Add(":", 10, Assoc.None);

            Add("|", 20, Assoc.None);

            Add("->", 30, Assoc.None, Operator.Arrow);

            Add("<|", 40, Assoc.Left);
            Add("|>", 40, Assoc.Left);

            Add("==", 100, Assoc.None);
            Add("!=", 100, Assoc.None);
            Add("/=", 100, Assoc.None);

            Add("<", 110, Assoc.None);
            Add("<=", 110, Assoc.None);
            Add(">", 110, Assoc.None);
            Add(">=", 110, Assoc.None);

            Add("||", 120, Assoc.Left);

            Add("+", 130, Assoc.Left);
            Add("++", 130, Assoc.Left);
            Add("::", 130, Assoc.Left);
            Add("-", 130, Assoc.Left);

            Add("*", 130, Assoc.Left);
            Add("/", 130, Assoc.Left);
            Add("//", 130, Assoc.Left);
            Add("%", 130, Assoc.Left);

            Add(".", 1000, Assoc.Left, Operator.Select);
        }

        public Prec this[string name]
        {
            get
            {
                return precs[name];
            }
        }

        public Operator Create(Token token)
        {
            if (precs.TryGetValue(token.Text, out var prec) && prec.Create != null)
            {
                return prec.Create(token);
            }
            return new Operator(token);
        }

        private void Add(string name, int prio, Assoc assoc, Func<Token,Operator>? create = null)
        {
            precs.Add(name, new Prec(name, prio, assoc, create));
        }

        public class Prec
        {
            public Prec(string name, int prio, Assoc assoc, Func<Token, Operator>? create = null)
            {
                Name = name;
                Precedence = prio;
                Assoc = assoc;
                Create = create;
            }

            public string Name { get; }
            public int Precedence { get; }
            public Assoc Assoc { get; }
            public Func<Token, Operator>? Create { get; }
        }

        public enum Assoc
        {
            None,
            Left,
            Right,
        }
    }
}
