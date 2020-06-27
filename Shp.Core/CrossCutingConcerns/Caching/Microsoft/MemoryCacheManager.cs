using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Shp.Core.Extensions;
using Shp.Core.Utilities.IoC;

namespace Shp.Core.CrossCutingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private IMemoryCache _cache;

        public MemoryCacheManager()
        {
            _cache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public T Get<T>(string key) => _cache.Get<T>(key);

        public object Get(string key) => _cache.Get(key);

        public void Add(string key, object data, int duration)
        {
            _cache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public bool isAdd(string key) => _cache.TryGetValue(key, out _);

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            _cache.RemoveByPattern(pattern);
        }
    }
}
