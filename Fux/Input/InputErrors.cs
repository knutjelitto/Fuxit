namespace Fux.Input
{
    internal class InputErrors
    {
        public InputErrors(ErrorBag errors)
        {
            Errors = errors;
        }

        public ErrorBag Errors { get; }

        protected DiagnosticException Add(params Diagnostic[] diagnostics)
        {
            var exception = new DiagnosticException(diagnostics);

            Errors.Add(exception);

            return exception;
        }
    }
}
