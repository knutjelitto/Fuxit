namespace Fux.Errors
{
    public abstract class Error : Diagnostic
    {
        protected Error() : base(Level.Error)
        {
        }
    }
}
