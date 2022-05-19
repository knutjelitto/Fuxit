namespace Fux.Errors
{
    public class DiagnosticException : Exception
    {
        public DiagnosticException(params Diagnostic[] diagnostics)
        {
            Diagnostics = diagnostics;
        }

        public Diagnostic[] Diagnostics { get; }

        public IEnumerable<string> Report()
        {
            foreach (var diagnostic in Diagnostics)
            {
                foreach (var line in diagnostic.Report())
                {
                    yield return line;
                }
            }
        }
    }
}
