namespace DraftInsights.NHLApi.Models;

public class PlayerStats
{
    public int Games { get; set; }

    public int Goals { get; set; }

    public int Assists { get; set; }

    public int Points { get; set; }

    public int? PlusMinus { get; set; }
}

public class PlayerStatsResponse
{
    public string Copyright { get; set; } = string.Empty;
    public List<Stat> Stats { get; set; } = new List<Stat>();
}

public class Split
{
    public PlayerStats? Stat { get; set; }
}

public class Stat
{
    public List<Split> Splits { get; set; } = new List<Split>();
}
