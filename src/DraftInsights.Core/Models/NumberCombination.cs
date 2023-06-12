namespace DraftInsights.Core.Models;

public class NumberCombination
{
    public NumberCombination(int[] numbers)
    {
        Numbers = numbers;
    }

    public int[] Numbers { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not NumberCombination combination)
        {
            return false;
        }

        return Numbers.OrderBy(x => x).SequenceEqual(combination.Numbers.OrderBy(x => x));
    }

    public override int GetHashCode() => base.GetHashCode();
}
