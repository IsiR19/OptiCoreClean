using Auth.Core.Common.Interfaces;

namespace Auth.Core.Common.Services.Providers
{
    public class NoCacheProvider : ICacheProvider
    {
        public void Clear()
        {
        }

        public void Delete(string key)
        { }

        public T Get<T>(string key)
        {
            return default(T);
        }

        public void Set<T>(string key, T value, int forceLifetimeMins = -1)
        { }

        public bool TryGet<T>(string key, out T value)
        {
            value = default(T);
            return false;
        }

    }
}