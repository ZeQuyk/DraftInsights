namespace DraftInsights.NHLApi.Models;

public class PlayerDetailResponse
{
    public PlayerDetailResponse()
    {
        People = new List<PlayerDetail>();
    }

    public List<PlayerDetail> People { get; set; }
}
