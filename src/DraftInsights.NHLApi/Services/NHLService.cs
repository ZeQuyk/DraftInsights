using DraftInsights.NHLApi.Clients;
using DraftInsights.NHLApi.Extensions;
using DraftInsights.NHLApi.Models;
using Microsoft.Extensions.Caching.Memory;

namespace DraftInsights.NHLApi.Services;

public class NHLService : INHLService
{
    public const int NhlLeagueId = 133;

    private const string TeamLogoUrlBase = "https://www-league.nhlstatic.com/images/logos/teams-current-primary-dark";

    private readonly INhlStatsClient _nhlStatsClient;
    private readonly INhlRecordsClient _nhlRecordsClient;
    private readonly IMemoryCache _memoryCache;

    public NHLService(INhlStatsClient nhlStatsClient, INhlRecordsClient nhlRecordsClient, IMemoryCache memoryCache)
    {
        _nhlStatsClient = nhlStatsClient;
        _nhlRecordsClient = nhlRecordsClient;
        _memoryCache = memoryCache;
    }

    public Task<StandingsResponse> GetStandingsAsync()
        => _nhlStatsClient.GetStandingsAsync();

    public Task<NhlDraftResponse?> GetDraftAsync(int year)
        => _nhlRecordsClient.GetDraftAsync(year);

    public Task<List<Stat>?> GetPlayersStatsAsync(int playerId, StatsTypes statsType)
    {
        return _memoryCache.GetOrCreateAsync($"player{playerId}_{statsType.GetStatsTypeString()}", (cacheEntry) =>
        {
            cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);

            return _nhlStatsClient.GetPlayerStatsAsync(playerId, statsType);
        });
    }

    public Task<PlayerDetail?> GetPlayerDetailAsync(int playerId)
    {
        return _memoryCache.GetOrCreateAsync($"playerdetail{playerId}", async (cacheEntry) =>
        {
            cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);

            var players = await _nhlStatsClient.GetPlayerDetailsAsync(playerId);

            return players.FirstOrDefault(p => p.Id == playerId);
        });
    }

    public string GetTeamLogoUrl(int teamId)
        => $"{TeamLogoUrlBase}/{teamId}.svg";

    public DateTime GetSeasonStartDate(int year)
        => new(year, 9, 15);
}
