using DraftInsights.NHLApi.Models;

namespace DraftInsights.NHLApi.Clients;

public interface INhlStatsClient
{
    Task<StandingsResponse> GetStandingsAsync();

    Task<List<Stat>> GetPlayerStatsAsync(int playerId, StatsTypes statsType);

    Task<List<PlayerDetail>> GetPlayerDetailsAsync(int playerId);
}