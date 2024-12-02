using Microsoft.Extensions.Configuration;
using StayFit.Application.Abstracts.Services;
using StayFit.Application.DTOs.WeeklyProgresses;
using System.Text.Json;
using System.Text;
using MediatR;

public class BodyAnalysisAIService : IBodyAnalysisAIService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;

    public BodyAnalysisAIService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiUrl = configuration["AIServices:BodyAnalysis:Endpoint"]
                  ?? throw new ArgumentNullException("API URL is not configured.");
    }

    public async Task<BodyAnalaysisResponseDto> AnalyzeBodyMetrics(BodyAnalysisRequestDto bodyAnalysisRequestDto)
    {
        var jsonContent = JsonSerializer.Serialize(bodyAnalysisRequestDto);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(_apiUrl, httpContent);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"API call failed with status code: {response.StatusCode}");
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        var jsonDocument = JsonDocument.Parse(responseContent);
        var dataString = jsonDocument.RootElement.GetProperty("data").GetString();

        if (string.IsNullOrEmpty(dataString))
            throw new Exception("Data field is null or empty.");

        dataString = dataString.Replace("'", "\"");

        return JsonSerializer.Deserialize<BodyAnalaysisResponseDto>(dataString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}
