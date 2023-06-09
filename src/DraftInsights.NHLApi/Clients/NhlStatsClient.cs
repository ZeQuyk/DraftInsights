using DraftInsights.NHLApi.Models;
using DraftInsights.NHLApi.Serialization;

namespace DraftInsights.NHLApi.Clients;

public class NhlStatsClient : ClientBase, INhlStatsClient
{
    public NhlStatsClient(HttpClient httpClient)
        : base(httpClient, "https://statsapi.web.nhl.com/")
    {
    }

    public async Task<StandingsResponse> GetStandingsAsync()
    {
        using var response = await HttpClient.GetAsync("api/v1/standings/byLeague");
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

    public async Task<PlayerStats?> GetPlayerStatsAsync(int playerId)
    {
        using var response = await HttpClient.GetAsync($"api/v1/people/{playerId}/stats?stats=careerRegularSeason");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Invalid response");
        }

        var json = await response.Content.ReadAsStringAsync();
        var stats = JsonSerializer.Deserialize<PlayerStatsResponse?>(json);
        if (stats == null)
        {
            return null;
        }

        return stats.Stats.FirstOrDefault()?.Splits.FirstOrDefault()?.Stat;
    }

}
