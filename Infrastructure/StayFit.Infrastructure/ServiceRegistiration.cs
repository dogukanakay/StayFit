using Microsoft.Extensions.DependencyInjection;
using StayFit.Application.Abstracts.Security;
using StayFit.Application.Abstracts.Services;
using StayFit.Application.Abstracts.Storage;
using StayFit.Infrastructure.Helpers;
using StayFit.Infrastructure.Storage;

namespace StayFit.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static void AddInfrastructureServices(this IServiceCollection service)
        {
            service.AddScoped<IStorageService, StorageService>();
            service.AddScoped<IHashingHelper, HashingHelper>();
            service.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            service.AddHttpClient<IBodyAnalysisAIService, BodyAnalysisAIService>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
