using DraftInsights.NHLApi.Clients;
using DraftInsights.NHLApi.Models;

namespace DraftInsights.NHLApi.Services;

public class NHLService : INHLService
{
    private const string TeamLogoUrlBase = "https://www-league.nhlstatic.com/images/logos/teams-current-primary-dark";

    private readonly INhlStatsClient _nhlStatsClient;
    private readonly INhlRecordsClient _nhlRecordsClient;

    public NHLService(INhlStatsClient nhlStatsClient, INhlRecordsClient nhlRecordsClient)
    {
        _nhlStatsClient = nhlStatsClient;
        _nhlRecordsClient = nhlRecordsClient;
    }

    public Task<StandingsResponse> GetStandingsAsync()
        => _nhlStatsClient.GetStandingsAsync();

    public Task<NhlDraftResponse?> GetDraftAsync(int year)
        => _nhlRecordsClient.GetDraftAsync(year);

    public string GetTeamLogoUrl(int teamId)
        => $"{TeamLogoUrlBase}/{teamId}.svg";
}
