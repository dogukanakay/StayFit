using MediatR;
using StayFit.Application.Abstracts.Caching;
using StayFit.Application.CustomAttributes.Caching;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace StayFit.Application.PipelineBehaviors.Caching
{
    public class CacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ICacheService _cacheService;

        public CacheBehavior(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Handler'ın tipini al
            var handlerType = typeof(TRequest).Assembly.GetTypes()
                .FirstOrDefault(t => t.GetInterfaces().Contains(typeof(IRequestHandler<TRequest, TResponse>)));

            if (handlerType == null) return await next();

            // Handler üzerindeki methodu al
            var methodInfo = handlerType.GetMethod("Handle");

            if (methodInfo == null) return await next();

            // Handle metodunda tanımlı CacheAttribute'ü al
            var cacheAttribute = methodInfo.GetCustomAttribute<CacheAttribute>();

            if (cacheAttribute == null) return await next();

            var cacheKey = cacheAttribute.CacheKey;

            // Cache'te var mı kontrol et
            var cachedResponse = await _cacheService.GetAsync<TResponse>(cacheKey);
            if (cachedResponse != null)
                return cachedResponse;

            // Cache yoksa, işleme devam et
            var response = await next();

            // Cache'e ekle
            await _cacheService.SetAsync(cacheKey, response, TimeSpan.FromSeconds(cacheAttribute.ExpirationInSeconds));

            return response;
        }
    }
}
