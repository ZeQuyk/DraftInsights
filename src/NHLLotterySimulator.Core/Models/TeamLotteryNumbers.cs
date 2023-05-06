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

    public bool HasNumberCombination(NumberCombination numberCombination)
        => NumberCombinations.Any(n => n.Equals(numberCombination));
}
