using MediatR;
using StayFit.Application.Abstracts.Caching;
using StayFit.Application.CustomAttributes.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.PipelineBehaviors.Caching
{
    public class CacheRemoveBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly ICacheService _cacheService;

        public CacheRemoveBehavior(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();


            var handlerType = next.Target?.GetType();
            var methodInfo = handlerType?.GetMethod("Handle");


            var cacheRemoveAttribute = methodInfo?.GetCustomAttribute<CacheRemoveAttribute>();
            if (cacheRemoveAttribute == null)
                return response;

          
            if (IsSuccessful(response))
            {
                await _cacheService.RemoveAsync(cacheRemoveAttribute.CacheKey);
                // eğer prefix ile sileeceksek
                // await _cacheService.RemoveByPrefixAsync(cacheRemoveAttribute.CacheKey);
            }

            return response;
        }

        private bool IsSuccessful(TResponse response)
        {
           
            if (response?.GetType().GetProperty("Success")?.GetValue(response) is bool success)
                return success;

            return true; 
        }
    }
}
