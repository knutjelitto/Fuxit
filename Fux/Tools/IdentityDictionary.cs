namespace Fux.Tools
{
    public class IdentityDictionary<TKey, TValue> : Dictionary<TKey, TValue>
        where TKey : class
    {
        public IdentityDictionary()
            : base(new IdentityEquality<TKey>())
        {
        }
    }
}
