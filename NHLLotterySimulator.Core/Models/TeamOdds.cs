namespace NHLLotterySimulator.Core.Models;

public class TeamOdds
{
    public TeamOdds(string team, decimal odds)
    {
        Team = team;
        Odds = odds;
    }

    public string Team { get; set; }

    public decimal Odds { get; set; }
}
