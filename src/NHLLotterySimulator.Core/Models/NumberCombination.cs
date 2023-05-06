namespace NHLLotterySimulator.Core.Models;

public class NumberCombination
{
    public NumberCombination(int[] numbers)
    {
        Numbers = numbers;
    }

    public int[] Numbers { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not NumberCombination combination)
        {
            return false;
        }

        return Numbers.SequenceEqual(combination.Numbers);
    }

    public override int GetHashCode() => base.GetHashCode();
}
