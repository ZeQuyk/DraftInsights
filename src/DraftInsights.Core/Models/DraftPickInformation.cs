using DraftInsights.NHLApi.Models;

namespace DraftInsights.Core.Models;

public class DraftPickInformation
{
    public DraftPickInformation(DraftPick pick, PlayerStats? stats)
    {
        Pick = pick;
        PlayerStats = stats;
    }

    public DraftPick Pick { get; set; }

    public PlayerStats? PlayerStats { get; set; }
}
