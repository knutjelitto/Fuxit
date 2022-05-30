namespace Fux
{
    internal class ErrorBag
    {
        private readonly List<DiagnosticException> exceptions = new();
        private readonly int few = 10;

        public bool Ok => exceptions.Count == 0;

        public void Add(DiagnosticException exception)
        {
            exceptions.Add(exception);
        }

        public void ReportFirstFew(Writer writer)
        {
            var count = 0;

            foreach (var exception in exceptions)
            {
                foreach (var diagnostic in exception.Diagnostics)
                {
                    foreach (var line in diagnostic.Report())
                    {
                        writer.WriteLine(line);
                    }
                }

                if (++count == few)
                    break;
            }
        }
    }
}
