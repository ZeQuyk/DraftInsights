using DraftInsights.NHLApi.Models;

namespace DraftInsights.NHLApi.Clients
{
    public interface INhlStatsClient
    {
        Task<StandingsResponse> GetStandingsAsync();
    }
}