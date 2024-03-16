using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Common.Interfaces
{
    public interface ICacheProvider
    {
        void Delete(string key);
        void Clear();

        T Get<T>(string key);

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="forceLifetimeMins">If set, this will override the configured life time of cache item</param>
        void Set<T>(string key, T value, int forceLifetimeMins = -1);

        bool TryGet<T>(string key, out T value);
    }
}
