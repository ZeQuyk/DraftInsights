using DraftInsights.NHLApi.Models;

namespace DraftInsights.NHLApi.Services
{
    public interface INHLService
    {
        Task<StandingsResponse> GetStandingsAsync();

        Task<NhlDraftResponse?> GetDraftAsync(int year);
    }
}