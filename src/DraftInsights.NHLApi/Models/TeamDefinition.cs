namespace DraftInsights.NHLApi.Models;

public class TeamDefinition
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Link { get; set; } = string.Empty;

    public string LogoUrl => $"https://www-league.nhlstatic.com/images/logos/teams-current-primary-dark/{Id}.svg";
}
