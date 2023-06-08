using DraftInsights.NHLApi.Models;

namespace DraftInsights.NHLApi.Clients
{
    public interface INhlRecordsClient
    {
        Task<NhlDraftResponse?> GetDraftAsync(int year);
    }
}