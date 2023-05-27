using System.Text.Json.Serialization;

namespace NHLLotterySimulator.NHLApi.Models;

public class StandingsResponse
{
    public StandingsResponse()
    {
        Standings = new List<Standing>();
        Copyright = string.Empty;
    }

    public string Copyright { get; set; }

    [JsonPropertyName("records")]
    public List<Standing> Standings { get; set; }

    public Standing NhlStandings => Standings.First();
}
