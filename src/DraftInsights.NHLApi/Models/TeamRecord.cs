using System.Text.Json.Serialization;

namespace DraftInsights.NHLApi.Models;

public class TeamRecord
{
    public TeamDefinition? Team { get; set; }

    public LeagueRecord? LeagueRecord { get; set; }

    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int LeagueRank { get; set; }

    public string? ClinchIndicator { get; set; }

    public bool IsPlayoffTeam() => !string.IsNullOrWhiteSpace(ClinchIndicator);
}
