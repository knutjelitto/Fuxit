namespace Fux.Errors
{
    public class DiagnosticException : Exception
    {
        public DiagnosticException(params Diagnostic[] diagnostics)
        {
            Diagnostics = diagnostics;
        }

        public Diagnostic[] Diagnostics { get; }
    }
}
