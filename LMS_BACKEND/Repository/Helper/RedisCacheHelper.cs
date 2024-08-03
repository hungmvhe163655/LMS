using Contracts;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Helper
{
    public class RedisCacheHelper : IRedisCacheHelper
    {
        private readonly IDistributedCache _cache;

        public RedisCacheHelper(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetCacheAsync<T>(string cacheKey)
        {
            var cachedData = await _cache.GetStringAsync(cacheKey);

            if (string.IsNullOrEmpty(cachedData))
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(cachedData);
        }

        public async Task SetCacheAsync<T>(string cacheKey, T value, TimeSpan expirationTime)
        {
            var serializedData = JsonConvert.SerializeObject(value);
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expirationTime
            };
            await _cache.SetStringAsync(cacheKey, serializedData, options);
        }

        public async Task RemoveCacheAsync(string cacheKey)
        {
            await _cache.RemoveAsync(cacheKey);
        }
    }
}
