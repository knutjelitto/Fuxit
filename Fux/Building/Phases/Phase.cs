﻿namespace Fux.Building.Phases
{
    public abstract class Phase
    {
        protected Phase(string phaseName, Ambience ambience, Package package)
        {
            PhaseName = phaseName;
            Ambience = ambience;
            Package = package;
        }

        public Collector Collector => Collector.Instance;


        public string PhaseName { get; }
        public Ambience Ambience { get; }
        public ErrorBag Errors => Ambience.Errors;
        public Package Package { get; }

        public abstract void Make();

        protected Writer MakeWriter()
        {
            return Writer.Null();
        }

        protected Writer MakeWriter(string name)
{
            var writer = name.Writer();

            writer.WriteLine($"-- {DateTime.Now} - {name}");
            writer.WriteLine();

            return writer;
        }

        protected Writer MakeWriter(Module module)
        {
            return MakeWriter(module, PhaseName);
        }

        protected Writer MakeWriter(Package package)
        {
            return MakeWriter(package.FullName + "/Typing.text");
        }

        protected Writer MakeWriter(Module module, string phase)
        {
            return MakeWriter(module.NickName, phase);
        }

        protected Writer MakeWriter(string prefix, string phase)
        {
            return MakeWriter($"{prefix}-{phase}.text");
        }
    }
}
