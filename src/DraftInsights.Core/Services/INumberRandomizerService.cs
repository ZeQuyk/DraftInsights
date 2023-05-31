using DraftInsights.Core.Models;

namespace DraftInsights.Core.Services;

public interface INumberRandomizerService
{
    List<TeamLotteryNumbers> AssignNumbers(IEnumerable<TeamOdds> teamOdds);

    NumberCombination DrawWinningCombination();
}