using Auth.Core.Common.Interfaces;
using Auth.Core.Common.Models;
using Auth.Core.Interfaces.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Common.Services.Providers
{
    public class FileCacheProvider : ICacheProvider, IDisposable
    {
        #region Private Fields
        private HashSet<string> _keys { get; set; }
        private readonly CacheConfiguration _config;
        private bool _disposed = false;

        #endregion Private Fields

        #region Private Properties

        private string _directory => "_cache";

        #endregion Private Properties

        #region Public Constructors

        public FileCacheProvider(CacheConfiguration config)
        {
            _config = config;
            if (!Directory.Exists(_directory))
            {
                Directory.CreateDirectory(_directory);
            }
            _keys = new HashSet<string>();
            new Thread(() => { CheckDir(); }).Start();
        }

        #endregion Public Constructors

        #region Public Methods

        public void Delete(string key)
        {
            if (File.Exists(getFileName(key)))
            {
                File.Delete(getFileName(key));
            }
        }

        public void Dispose()
        {
            _disposed = true;
        }

        public T Get<T>(string key)
        {
            try
            {
                FileCacheItem<T> item = GetItem<T>(key);
                if (item == null) return default(T);
                return item.Data;
            }
            catch { return default(T); }
        }

        public void Set<T>(string key, T value, int forceLifetimeMins = -1)
        {
            try
            {
                FileCacheItem<T> item = new FileCacheItem<T>()
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(forceLifetimeMins > -1 ? forceLifetimeMins : this._config.LifetimeMins),
                    Data = value
                };
                string filename = getFileName(key);
                File.WriteAllText(filename, item.ToJson());
            }
            catch { }
        }

        public bool TryGet<T>(string key, out T value)
        {
            value = default(T);
            try
            {
                FileCacheItem<T> item = GetItem<T>(key);
                if (item == null)
                {
                    return false;
                }
                else
                {
                    value = item.Data;
                    return true;
                }
            }
            catch { return false; }
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

        #region Private Methods

        private void CheckDir()
        {
            var waitMs = _config.LifetimeMins * 60 * 1000;
            while (!_disposed)
            {
                var files = Directory.GetFiles(_directory, "*.cf");
                foreach (var file in files)
                {
                    // CheckFile(file);
                }
                Thread.Sleep(waitMs);
            }
        }

        private void CheckFile(string fileName)
        {
            if (!File.Exists(fileName)) return;
            string contents = File.ReadAllText(fileName);
            FileCacheItem<object> item = FileCacheItem<object>.FromJson(contents);
            if (item.AbsoluteExpiration < DateTime.Now)
            {
                File.Delete(fileName);
            }
        }

        private string getFileName(string key)
        {
            return Path.Combine(_directory, $"_{key}.cf");
        }

        private FileCacheItem<T> GetItem<T>(string key)
        {
            try
            {
                string fileName = getFileName(key);
                string contents = File.ReadAllText(fileName);
                FileCacheItem<T> item = FileCacheItem<T>.FromJson(contents);
                if (item.AbsoluteExpiration > DateTime.Now)
                {
                    return item;
                }
                else
                {
                    TryDelete(fileName);
                    return null;
                }
            }
            catch { return null; }
        }

        private void TryDelete(string filename)
        {
            if (File.Exists(filename))
            {
                string key = new FileInfo(filename).Name.TrimStart('_').Replace(".cf", "");
                _keys.Remove(key);
                File.Delete(filename);
            }
        }

        #endregion Private Methods
    }
}
