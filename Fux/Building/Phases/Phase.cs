using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fux.Building.Phases
{
    internal abstract class Phase
    {
        protected Phase(string name, ErrorBag errors, Package package)
        {
            Name = name;
            Errors = errors;
            Package = package;
        }


        public string Name { get; }
        public ErrorBag Errors { get; }
        public Package Package { get; }

        public abstract void Make();

        protected Writer MakeWriter(string name)
{
            var writer = name.Writer();

            writer.WriteLine($"-- {DateTime.Now} - {name}");
            writer.WriteLine();

            return writer;
        }

        protected Writer MakeWriter(Module module, string phase)
        {
            var writer = (module.NickName + $"-{phase}.txt").Writer();

            writer.WriteLine($"-- {phase} {DateTime.Now} - {module}");
            writer.WriteLine();

            return writer;
        }
    }
}
