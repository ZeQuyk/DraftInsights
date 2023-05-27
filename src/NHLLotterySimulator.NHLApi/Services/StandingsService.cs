using System.Text.Json;
using NHLLotterySimulator.NHLApi.Models;

namespace NHLLotterySimulator.NHLApi.Services;

public class StandingsService
{
    private JsonSerializerOptions? _serializerOptions;
    private readonly HttpClient _httpClient;

    public StandingsService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://statsapi.web.nhl.com/"),
        };
    }

    public async Task<StandingsResponse> GetStandingsAsync()
    {
        var response = await _httpClient.GetAsync("api/v1/standings/byLeague");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Invalid response");
        }

        var res = await response.Content.ReadAsStringAsync();
        var standings = JsonSerializer.Deserialize<StandingsResponse>(res, GetSerializerOptions());
        if (standings == null)
        {
            throw new Exception("response is null");
        }

        return standings;
    }

    private JsonSerializerOptions GetSerializerOptions()
    {
        if (_serializerOptions == null)
        {
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }

        return _serializerOptions;
    }
}
