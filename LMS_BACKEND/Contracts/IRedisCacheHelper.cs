using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRedisCacheHelper
    {
        Task<T?> GetCacheAsync<T>(string cacheKey);

        Task SetCacheAsync<T>(string cacheKey, T value, TimeSpan expirationTime);

        Task RemoveCacheAsync(string cacheKey);
    }
}
