namespace DraftInsights.NHLApi.Clients;

public abstract class ClientBase
{
    public ClientBase(HttpClient httpClient, string baseUrl)
    {
        HttpClient = httpClient;
        HttpClient.BaseAddress = new Uri(baseUrl);
    }

    protected HttpClient HttpClient { get; private init; }
}
