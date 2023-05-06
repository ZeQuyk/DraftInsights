using NHLLotterySimulator.Core.Models;

namespace NHLLotterySimulator.Core.Services;

public class NumberRandomizerService
{
    private const int LowestNumber = 1;
    private const int HighestNumber = 14;
    private const int NumbersByCombination = 4;

    public List<TeamLotteryNumbers> AssignNumbers(IEnumerable<TeamOdds> teamOdds)
    {
        /* 
            From The Athletic's Aaron Portzline https://theathletic.com/4453404/2023/05/05/nhl-draft-lottery-format-rules-odds/:
            First, 14 ping-pong balls are loaded into a lottery machine, each of them labeled with a number between 1 and 14 (1, 2, 3, etc.).
            Why 14? Because there are 1,001 different four-digit number combinations between 1 and 14, and the league needs 1,000 different possible numbers to conduct its lottery.
            One of the 1,001 number combinations is chosen at random and is removed from the pool of possible numbers, leaving the process with an even 1,000 numbers.
         */
        var numbers = GetNumberCombinations();
        foreach (var number in numbers)
        {
            Console.WriteLine(string.Join("-", number) + "\n");
        }

        return new List<TeamLotteryNumbers>();
    }

    private static IEnumerable<int[]> GetNumberCombinations()
    {
        var result = new int[NumbersByCombination];
        var stack = new Stack<int>();
        stack.Push(1);

        while (stack.Count > 0)
        {
            var index = stack.Count - 1;
            var value = stack.Pop();

            while (value <= HighestNumber)
            {
                result[index++] = value++;
                stack.Push(value);
                if (index == NumbersByCombination)
                {
                    yield return result;
                    break;
                }
            }
        }
    }
}
