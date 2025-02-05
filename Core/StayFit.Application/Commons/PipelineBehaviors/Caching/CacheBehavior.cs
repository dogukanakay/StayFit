using MediatR;
using StayFit.Application.Abstracts.Caching;
using StayFit.Application.Commons.CustomAttributes.Caching;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace StayFit.Application.Commons.PipelineBehaviors.Caching
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
            var handlerType = typeof(TRequest).Assembly.GetTypes()
                .FirstOrDefault(t => t.GetInterfaces().Contains(typeof(IRequestHandler<TRequest, TResponse>)));

            if (handlerType == null) return await next();

            var methodInfo = handlerType.GetMethod("Handle");

            if (methodInfo == null) return await next();

            var cacheAttribute = methodInfo.GetCustomAttribute<CacheAttribute>();

            if (cacheAttribute == null) return await next();

            var cacheKey = CreateKey.ReplacePlaceholders(cacheAttribute.CacheKey, request);
            var cachedResponse = await _cacheService.GetAsync<TResponse>(cacheKey);

            if (cachedResponse != null) return cachedResponse;

            var response = await next();
            await _cacheService.SetAsync(cacheKey, response, TimeSpan.FromSeconds(cacheAttribute.ExpirationInSeconds));

            return response;
        }
    }
}
