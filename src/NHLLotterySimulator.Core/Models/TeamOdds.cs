namespace NHLLotterySimulator.Core.Models;

public class TeamOdds
{
    public TeamOdds(int leagueRank, decimal odds)
    {
        LeagueRank = leagueRank;
        Odds = odds;
    }

    public int LeagueRank { get; set; }

    public decimal Odds { get; set; }
}
