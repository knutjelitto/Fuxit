using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Ast
{
    internal class Infix
    {
        public static readonly Infix Instance = new Infix();

        private readonly Dictionary<string,Prec> precs = new();

        private Infix()
        {
            Add("=", 10, Assoc.None);

            Add("==", 100, Assoc.None);
            Add("!=", 100, Assoc.None);

            Add("<", 110, Assoc.None);
            Add("<=", 110, Assoc.None);
            Add(">", 110, Assoc.None);
            Add(">=", 110, Assoc.None);

            Add("+", 120, Assoc.Left);
            Add("-", 120, Assoc.Left);

            Add("*", 130, Assoc.Left);
            Add("/", 130, Assoc.Left);
        }

        public Prec this[string name]
        {
            get
            {
                return precs[name];
            }
        }

        private void Add(string name, int prio, Assoc assoc)
        {
            precs.Add(name, new Prec(name, prio, assoc));
        }

        public class Prec
        {
            public Prec(string name, int prio, Assoc assoc)
            {
                Name = name;
                Precedence = prio;
                Assoc = assoc;
            }

            public string Name { get; }
            public int Precedence { get; }
            public Assoc Assoc { get; }
        }

        public enum Assoc
        {
            None,
            Left,
            Right,
        }
    }
}
