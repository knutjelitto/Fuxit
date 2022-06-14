namespace Fux.Tools
{
    public class IdentityDictionary<TKey, TValue> : Dictionary<TKey, TValue>
        where TKey : class
    {
        public IdentityDictionary()
            : base(new IdentityEquality<TKey>())
        {
        }
        public IdentityDictionary(IdentityDictionary<TKey, TValue> items)
            : base(items, new IdentityEquality<TKey>())
        {
        }

        public IdentityDictionary<TKey, TValue> Clone()
        {
            return new IdentityDictionary<TKey, TValue>(this);
        }
    }
}
