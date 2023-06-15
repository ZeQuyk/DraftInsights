using DraftInsights.NHLApi.Extensions;
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
        if (standings is null)
        {
            throw new Exception("response is null");
        }

        return standings;
    }

    public async Task<List<Stat>> GetPlayerStatsAsync(int playerId, StatsTypes statsType)
    {
        using var response = await HttpClient.GetAsync($"api/v1/people/{playerId}/stats?stats={statsType.GetStatsTypeString()}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Invalid response");
        }

        var json = await response.Content.ReadAsStringAsync();
        var stats = JsonSerializer.Deserialize<PlayerStatsResponse?>(json);
        if (stats is null)
        {
            return new List<Stat>();
        }

        return stats.Stats;
    }

}
