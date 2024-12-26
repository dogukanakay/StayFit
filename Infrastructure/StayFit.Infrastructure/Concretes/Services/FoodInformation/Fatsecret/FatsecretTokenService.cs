using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StayFit.Application.Abstracts.Services.FoodInformationServices.FatsecretService;
using StayFit.Application.DTOs.FoodInformations.Fatsecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Infrastructure.Concretes.Services.FoodInformation.Fatsecret
{
    public class FatsecretTokenService : IFatsecretTokenService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private const string CACHE_KEY = "FatSecretAccessToken";

        public FatsecretTokenService(IMemoryCache memoryCache, IConfiguration configuration)
        {
            _memoryCache = memoryCache;
            _clientId = configuration["Fatsecret:ClientId"];
            _clientSecret = configuration["Fatsecret:ClientSecret"];
        }

        public async Task<string> GetAccessTokenAsync()
        {
            if (_memoryCache.TryGetValue(CACHE_KEY, out string cachedToken))
            {
                return cachedToken;
            }

            var token = await GetNewTokenAsync();
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(token.ExpiresIn - 300));

            _memoryCache.Set(CACHE_KEY, token.AccessToken, cacheOptions);

            return token.AccessToken;
        }

        private async Task<FatsecretTokenResponse> GetNewTokenAsync()
        {
            using var client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes($"{_clientId}:{_clientSecret}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var values = new Dictionary<string, string>
        {
            { "scope", "premier" },
            { "grant_type", "client_credentials" }
        };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://oauth.fatsecret.com/connect/token", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Token alınamadı. Status: {response.StatusCode}");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FatsecretTokenResponse>(jsonResponse);
        }
    }
}