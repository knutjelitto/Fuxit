namespace Fux.Ast
{
    internal abstract class Expression
    {
        public abstract bool IsAtomic { get; }

        public abstract void PP(Writer writer);
    }
}
