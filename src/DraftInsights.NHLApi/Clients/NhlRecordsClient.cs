using DraftInsights.NHLApi.Models;
using DraftInsights.NHLApi.Serialization;

namespace DraftInsights.NHLApi.Clients;

public class NhlRecordsClient : ClientBase, INhlRecordsClient
{
    public NhlRecordsClient(HttpClient httpClient)
        : base(httpClient, "https://records.nhl.com/site/api/")
    {
    }

    public async Task<NhlDraftResponse?> GetDraftAsync(int year)
    {
        using var response = await HttpClient.GetAsync($"draft?cayenneExp=draftYear={year}");
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Invalid response");
        }

        var json = await response.Content.ReadAsStringAsync();
        var draft = JsonSerializer.Deserialize<NhlDraftResponse>(json);
        if (draft is null)
        {
            throw new Exception("response is null");
        }

        return draft;
    }
}
