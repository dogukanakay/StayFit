using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using StayFit.Application.Abstracts.Caching;
using StayFit.Application.Abstracts.Security;
using StayFit.Application.Abstracts.Services;
using StayFit.Application.Abstracts.Services.BackgroundServices;
using StayFit.Application.Abstracts.Services.FoodInformationServices.FatsecretService;
using StayFit.Application.Abstracts.Services.GenerativeAIServices;
using StayFit.Application.Abstracts.Services.TranslationServices;
using StayFit.Application.Abstracts.Storage;
using StayFit.Application.DTOs.FoodInformations.Fatsecrets;
using StayFit.Infrastructure.Concretes.Services.AIServices.GenerativeAIServices;
using StayFit.Infrastructure.Concretes.Services.BackgroundServices;
using StayFit.Infrastructure.Concretes.Services.CachingServices;
using StayFit.Infrastructure.Concretes.Services.FoodInformation.Fatsecret;
using StayFit.Infrastructure.Concretes.Services.TranslationServices;
using StayFit.Infrastructure.Helpers;
using StayFit.Infrastructure.Storage;
using System.Net.Http.Headers;

namespace StayFit.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IHashingHelper, HashingHelper>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddHttpClient<IBodyAnalysisAIService, BodyAnalysisAIService>();
            services.AddScoped<IBodyAnalysisBackgroundService, BodyAnalysisBackgroundService>();
            services.AddHttpClient<IGeminiService, GeminiService>();
            services.AddScoped<IGetNewDietByAIBackgroundService, GetNewDietByAIBackgroundService>();

            services.AddMemoryCache();
            services.AddScoped<IFatsecretTokenService, FatsecretTokenService>();

            services.AddHttpClient<IFatsecretService, FatsecretService>(client =>
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddHangfire(config =>
                config.UsePostgreSqlStorage(configuration.GetConnectionString("Hangfire")));
            services.AddHangfireServer();


            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));
            services.AddSingleton<ICacheService, RedisCacheService>();

            services.AddScoped<ITranslationService, GoogleTranslationService>();


            

        }

        public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
