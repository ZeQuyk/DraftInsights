using DraftInsights.NHLApi.Models;

namespace DraftInsights.NHLApi.Services;

public interface INHLService
{
    Task<StandingsResponse> GetStandingsAsync();

    Task<NhlDraftResponse?> GetDraftAsync(int year);

    Task<List<Stat>?> GetPlayersStatsAsync(int playerId, StatsTypes statsType);

    string GetTeamLogoUrl(int teamId);

    Task<PlayerDetail?> GetPlayerDetailAsync(int playerId);

    DateTime GetSeasonStartDate(int year);
}