using Auth.Core.Common.Interfaces;
using Auth.Core.Common.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Auth.Core.Common.Services.Providers
{
    public class MemoryCacheProvider : ICacheProvider
    {
        #region Private Fields

        private readonly CacheConfiguration _config;
        private readonly IMemoryCache _memoryCache;

        #endregion Private Fields

        #region Public Constructors

        public MemoryCacheProvider(CacheConfiguration config)
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
            _config = config;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        #endregion Public Constructors

        #region Public Methods

        public void Delete(string key)
        {
            _memoryCache.Remove(key);
        }

        public T Get<T>(string key)
        {
            var res = _memoryCache.Get(key);
            if (res == null) return default(T);
            return (T)res;
        }

        public void Set<T>(string key, T value, int forceLifetimeMins = -1)
        {
            var options = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(forceLifetimeMins > -1 ? forceLifetimeMins : _config.LifetimeMins),
                Priority = CacheItemPriority.High
            };
            _memoryCache.Set(key, value, options);
        }

        public bool TryGet<T>(string key, out T value)
        {
            var res = _memoryCache.Get(key);
            if (res == null)
            {
                value = default(T);
                return false;
            }
            value = (T)res;
            return true;
        }

        #endregion Public Methods
    }
}
