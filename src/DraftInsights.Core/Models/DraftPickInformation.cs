using DraftInsights.NHLApi.Models;

namespace DraftInsights.Core.Models;

public class DraftPickInformation : PlayerBase
{
    public DraftPickInformation(DraftPick pick)
    {
        Pick = pick;
    }

    public DraftPick Pick { get; set; }

    public PlayerStats? PlayerStats { get; set; }

    public override int Id => Pick.PlayerId.GetValueOrDefault();

    public override string FullName => Pick.PlayerName;

    public string GetAmateurTeamString()
    {
        var text = Pick.AmateurClubName;
        if (!string.IsNullOrEmpty(Pick.AmateurLeague))
        {
            text += $" [{Pick.AmateurLeague}]";
        }

        return text;
    }
}
