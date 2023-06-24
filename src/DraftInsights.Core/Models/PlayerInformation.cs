using DraftInsights.NHLApi.Models;
using DraftInsights.NHLApi.Services;

namespace DraftInsights.Core.Models;

public class PlayerInformation : PlayerBase
{
    public Stat? Stats { get; set; }

    public PlayerDetail? Player { get; set; }

    public override int Id => Player?.Id ?? default;

    public override string FullName => Player?.FullName ?? string.Empty;

    public string GetBirthLocation()
    {
        if (Player is null)
        {
            return string.Empty;
        }

        var items = new string[] { Player.BirthCity, Player.BirthStateProvince, Player.BirthCountry };

        return string.Join(", ", items.Where(i => !string.IsNullOrEmpty(i)));
    }

    public int? GetCurrentTeamId()
    {
        var nhlSeasons = Stats?.Splits.Where(s => s.League?.Id == NHLService.NhlLeagueId);
        if (nhlSeasons is null || !nhlSeasons.Any())
        {
            return null;
        }

        if (Player is null || Player.Active)
        {
            return nhlSeasons.LastOrDefault()?.Team?.Id;
        }

        return nhlSeasons.GroupBy(s => s.Team?.Id).Max()?.FirstOrDefault()?.Team?.Id;
    }
}
