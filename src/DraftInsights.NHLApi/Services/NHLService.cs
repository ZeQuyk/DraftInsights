using DraftInsights.NHLApi.Clients;
using DraftInsights.NHLApi.Models;

namespace DraftInsights.NHLApi.Services;

public class NHLService : INHLService
{
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
}
