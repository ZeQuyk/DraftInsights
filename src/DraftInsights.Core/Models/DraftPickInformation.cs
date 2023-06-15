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
}
