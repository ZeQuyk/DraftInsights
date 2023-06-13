using DraftInsights.NHLApi.Clients;
using DraftInsights.NHLApi.Models;
using Microsoft.Extensions.Caching.Memory;

namespace DraftInsights.NHLApi.Services;

public class NHLService : INHLService
{
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

    public Task<PlayerStats?> GetPlayersStatsAsync(int playerId)
    {
        return _memoryCache.GetOrCreateAsync($"player{playerId}", (cacheEntry) =>
        {
            cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);

            return _nhlStatsClient.GetPlayerStatsAsync(playerId);
        });
    }

    public string GetTeamLogoUrl(int teamId)
        => $"{TeamLogoUrlBase}/{teamId}.svg";
}
