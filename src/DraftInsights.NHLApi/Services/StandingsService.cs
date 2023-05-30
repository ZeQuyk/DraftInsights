using DraftInsights.NHLApi.Models;
using DraftInsights.NHLApi.Serialization;

namespace DraftInsights.NHLApi.Services;

public class StandingsService
{
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
        using var response = await _httpClient.GetAsync("api/v1/standings/byLeague");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Invalid response");
        }

        var json = await response.Content.ReadAsStringAsync();
        var standings = JsonSerializer.Deserialize<StandingsResponse>(json);
        if (standings == null)
        {
            throw new Exception("response is null");
        }

        return standings;
    }
}
