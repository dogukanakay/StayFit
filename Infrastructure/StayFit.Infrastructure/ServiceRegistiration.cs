using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StayFit.Application.Abstracts.Security;
using StayFit.Application.Abstracts.Services;
using StayFit.Application.Abstracts.Services.BackgroundServices;
using StayFit.Application.Abstracts.Services.GenerativeAIServices;
using StayFit.Application.Abstracts.Storage;
using StayFit.Application.Settings;
using StayFit.Infrastructure.Concretes.Services.AIServices.GenerativeAIServices;
using StayFit.Infrastructure.Concretes.Services.BackgroundServices;
using StayFit.Infrastructure.Helpers;
using StayFit.Infrastructure.Storage;

namespace StayFit.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static void AddInfrastructureServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<IStorageService, StorageService>();
            service.AddScoped<IHashingHelper, HashingHelper>();
            service.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            service.AddHttpClient<IBodyAnalysisAIService, BodyAnalysisAIService>();
            service.AddScoped<IBodyAnalysisBackgroundService, BodyAnalysisBackgroundService>();
            service.AddHttpClient<IGeminiService, GeminiService>();
            service.AddScoped<IGetNewDietByAIBackgroundService, GetNewDietByAIBackgroundService>();

            service.AddHangfire(config =>
                config.UsePostgreSqlStorage(configuration.GetConnectionString("Hangfire")));
            service.AddHangfireServer();


        }

        public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
