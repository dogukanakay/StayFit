using StackExchange.Redis;
using StayFit.Application.Abstracts.Caching;
using System.Text.Json;

namespace StayFit.Infrastructure.Concretes.Services.CachingServices
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _redisCon;
        private readonly IDatabase _cache;


        public RedisCacheService(
            IConnectionMultiplexer redisCon
            )
        {
            _redisCon = redisCon;
            _cache = redisCon.GetDatabase();
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _cache.StringGetAsync(key);
            return value.HasValue ? JsonSerializer.Deserialize<T>(value!) : default;
        }

        public async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> action, TimeSpan? expiration = null)
        {
            var value = await GetAsync<T>(key);
            if (value != null)
                return value;

            value = await action();
            await SetAsync(key, value, expiration);
            return value;
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            await _cache.StringSetAsync(key, serializedValue, expiration);
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.KeyDeleteAsync(key);
        }

        public async Task RemoveByPrefixAsync(string prefixKey)
        {
            var endpoints = _redisCon.GetEndPoints();
            var server = _redisCon.GetServer(endpoints.First());
            var keys = server.Keys(pattern: $"{prefixKey}*");

            foreach (var key in keys)
                await _cache.KeyDeleteAsync(key);
        }

        public async Task<bool> ExistsAsync(string key)
            => await _cache.KeyExistsAsync(key);

    }
}
