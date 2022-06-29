#pragma warning disable IDE1006 // Naming Styles


namespace Fux.TypeSystem.Abstract
{
    public abstract class Mono : WithFree
    {
        public abstract ISet<MonoVariable> free();
    }
}
