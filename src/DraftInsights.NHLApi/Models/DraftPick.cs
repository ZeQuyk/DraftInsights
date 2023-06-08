namespace DraftInsights.NHLApi.Models;

public class DraftPick
{
    public int Id { get; set; }

    public string AmateurClubName { get; set; } = string.Empty;

    public string AmateurLeague { get; set; } = string.Empty;

    public int DraftMasterId { get; set; }

    public int DraftYear { get; set; }

    public int DraftedByTeamId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public int? Height { get; set; }

    public string LastName { get; set; } = string.Empty;

    public object Notes { get; set; } = string.Empty;

    public int OverallPickNumber { get; set; }

    public int PickInRound { get; set; }

    public int? PlayerId { get; set; }

    public string PlayerName { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public int RoundNumber { get; set; }

    public string ShootsCatches { get; set; } = string.Empty;

    public string SupplementalDraft { get; set; } = string.Empty;

    public string TeamPickHistory { get; set; } = string.Empty;

    public string TriCode { get; set; } = string.Empty;

    public int? Weight { get; set; }
}
