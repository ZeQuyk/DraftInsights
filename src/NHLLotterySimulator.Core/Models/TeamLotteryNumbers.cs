namespace NHLLotterySimulator.Core.Models;

public class TeamLotteryNumbers
{
    public TeamLotteryNumbers(int leagueRank, NumberCombination[] numberCombinations)
    {
        LeagueRank = leagueRank;
        NumberCombinations = numberCombinations;
    }

    public int LeagueRank { get; set; }

    public NumberCombination[] NumberCombinations { get; set; }

    public bool HasNumberCombination(NumberCombination numberCombination)
        => NumberCombinations.Any(n => n.Equals(numberCombination));
}
