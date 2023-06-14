using DraftInsights.NHLApi.Models;

namespace DraftInsights.Core.Models;

public class DraftPickInformation : INhlPlayer
{
    public DraftPickInformation(DraftPick pick, PlayerStats? stats)
    {
        Pick = pick;
        PlayerStats = stats;
    }

    public DraftPick Pick { get; set; }

    public PlayerStats? PlayerStats { get; set; }

    public int Id => Pick.PlayerId.GetValueOrDefault();

    public string FullName => Pick.PlayerName;

    public string Url => $"player/{Id}?name={FullName}";
}
