namespace Fux.Errors
{
    public abstract class Diagnostic
    {
        public Diagnostic(Level level)
        {
            Level = level;
        }

        public Level Level { get; }

        public abstract IEnumerable<string> Report();
    }
}
