namespace DraftInsights.Core.Models;

public class TeamLotteryNumbers
{
    public TeamLotteryNumbers(int leagueRank, decimal odds, NumberCombination[] numberCombinations)
    {
        LeagueRank = leagueRank;
        Odds = odds;
        NumberCombinations = numberCombinations;
    }

    public int LeagueRank { get; set; }

    public decimal Odds { get; set; }

    public NumberCombination[] NumberCombinations { get; set; }

    public bool HasNumberCombination(NumberCombination numberCombination)
        => NumberCombinations.Any(n => n.Equals(numberCombination));
}
