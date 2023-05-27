using System.Text.Json.Serialization;

namespace NHLLotterySimulator.NHLApi.Models;

public class TeamRecord
{
    public TeamDefinition? Team { get; set; }

    public LeagueRecord? LeagueRecord { get; set; }

    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int LeagueRank { get; set; }
}
