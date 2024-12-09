using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Abstracts.Caching
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key);
        Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> action, TimeSpan? expiration = null);
        Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);
        Task RemoveAsync(string key);
        Task RemoveByPrefixAsync(string prefixKey);
        Task<bool> ExistsAsync(string key);
    }
}
