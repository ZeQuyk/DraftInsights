using System.Text.Json.Serialization;

namespace NHLLotterySimulator.NHLApi.Models;

public class LeagueRecord
{
    public int Wins { get; set; }

    public int Losses { get; set; }

    [JsonPropertyName("ot")]
    public int OvertimeLosses { get; set; }

    public override string ToString() => $"{Wins}-{Losses}-{OvertimeLosses}";
}
