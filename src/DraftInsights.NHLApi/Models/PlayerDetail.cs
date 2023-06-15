namespace DraftInsights.NHLApi.Models;

public class PlayerDetail
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Link { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PrimaryNumber { get; set; } = string.Empty;

    public string BirthDate { get; set; } = string.Empty;

    public string BirthCity { get; set; } = string.Empty;

    public string BirthStateProvince { get; set; } = string.Empty;

    public string BirthCountry { get; set; } = string.Empty;

    public string Nationality { get; set; } = string.Empty;

    public string Height { get; set; } = string.Empty;

    public int Weight { get; set; }

    public bool Active { get; set; }

    public bool Rookie { get; set; }

    public string ShootsCatches { get; set; } = string.Empty;

    public string RosterStatus { get; set; } = string.Empty;

    public Position? PrimaryPosition { get; set; }
}
