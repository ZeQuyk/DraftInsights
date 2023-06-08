using System.Text.Json.Serialization;

namespace DraftInsights.NHLApi.Models
{
    public class NhlDraftResponse
    {
        public NhlDraftResponse()
        {
            Picks = new List<DraftPick>();
        }

        [JsonPropertyName("data")]
        public List<DraftPick> Picks { get; set; }

        public int Total { get; set; }
    }
}
