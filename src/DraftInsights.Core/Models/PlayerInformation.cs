using DraftInsights.NHLApi.Models;

namespace DraftInsights.Core.Models;

public class PlayerInformation : PlayerBase
{
    public Stat? Stats { get; set; }

    public PlayerDetail? Player { get; set; }

    public override int Id => Player?.Id ?? default;

    public override string FullName => Player?.FullName ?? string.Empty;
}
