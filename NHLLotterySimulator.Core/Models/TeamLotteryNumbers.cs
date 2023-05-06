namespace NHLLotterySimulator.Core.Models;

public class TeamLotteryNumbers
{
    public TeamLotteryNumbers(string team, NumberCombination[] numberCombinations)
    {
        Team = team;
        NumberCombinations = numberCombinations;
    }

    public string Team { get; set; }

    public NumberCombination[] NumberCombinations { get; set; }
}
