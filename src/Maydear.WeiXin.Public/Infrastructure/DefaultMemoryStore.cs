using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Maydear.WeiXin.Public.Infrastructure
{
    public class DefaultMemoryStore : IStore
    {
        private IMemoryCache _cache;

        public DefaultMemoryStore()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }
        public Task<object> RetrieveAsync(string key)
        {
            object obj;
            _cache.TryGetValue(key, out obj);
            return Task.FromResult(obj);
        }

        public Task RemoveAsync(string key)
        {
            _cache.Remove(key);
            return Task.FromResult(0);
        }

        public Task RenewAsync(string key, object value, long expire)
        {
            var options = new MemoryCacheEntryOptions();
            options.SetAbsoluteExpiration(TimeSpan.FromSeconds(expire));
            _cache.Set(key, value, options);

            return Task.FromResult(0);
        }
    }
}
