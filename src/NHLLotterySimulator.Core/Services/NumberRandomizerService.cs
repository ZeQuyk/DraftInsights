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
        var numbers = InitializeNumberCombinations();
        Shuffle(numbers);
        if (numbers.Count % 2 == 1)
        {
            numbers.RemoveAt(numbers.Count - 1);
        }

        var result = new List<TeamLotteryNumbers>();
        var index = 0;
        var count = numbers.Count;
        foreach (var team in teamOdds)
        {
            var newIndex = (int)Math.Floor(team.Odds * count);
            var combinations = numbers.Skip(index).Take(newIndex).Select(x => new NumberCombination(x));
            result.Add(new TeamLotteryNumbers(team.LeagueRank, combinations.ToArray()));
            index = index + newIndex - 1;
        }

        return result;
    }

    public NumberCombination DrawWinningCombination()
    {
        var random = new Random();
        var numbers = new List<int>();
        for (int i = 0; i < NumbersByCombination; i++)
        {
            numbers.Add(random.Next(LowestNumber, HighestNumber));
        }

        return new NumberCombination(numbers.ToArray());
    }

    private static List<int[]> InitializeNumberCombinations()
    {
        var returnList = new List<int[]>();
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
                    var addedArray = new int[NumbersByCombination];
                    result.CopyTo(addedArray, 0);
                    returnList.Add(addedArray);
                    break;
                }
            }
        }

        return returnList;
    }

    private static void Shuffle<T>(List<T> array)
    {
        var random = new Random();
        int n = array.Count;
        while (n > 1)
        {
            int k = random.Next(n--);
            (array[k], array[n]) = (array[n], array[k]);
        }
    }
}
