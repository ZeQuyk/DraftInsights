using NHLLotterySimulator.Core.Models;

namespace NHLLotterySimulator.Core.Services;

public class LotterySimulatorService
{   
    public const int PicksSimulated = 2;

    private readonly NumberRandomizerService _randomizerService;    
    private readonly List<TeamOdds> _teamOdds = new List<TeamOdds>
    {
        new TeamOdds("Anaheim", 0.185M),
        new TeamOdds("Columbus", 0.135M),
        new TeamOdds("Chicago", 0.115M),
        new TeamOdds("San Jose", 0.095M),
        new TeamOdds("Montreal", 0.085M),
        new TeamOdds("Arizona", 0.075M),
        new TeamOdds("Philadelphia", 0.065M),
        new TeamOdds("Washington", 0.06M),
        new TeamOdds("Detroit", 0.05M),
        new TeamOdds("St. Louis", 0.035M),
        new TeamOdds("Vancouver", 0.03M),
        new TeamOdds("Arizona via Ottawa", 0.025M),
        new TeamOdds("Buffalo", 0.02M),
        new TeamOdds("Pittsburgh", 0.015M),
        new TeamOdds("Nashville", 0.005M),
        new TeamOdds("Calgary", 0.005M),
    };

    public LotterySimulatorService()
    {
        _randomizerService = new NumberRandomizerService();
    }

    public List<TeamLotteryNumbers> GetWinners()
    {
        var winners = new List<TeamLotteryNumbers>();
        var teamNumbers = _randomizerService.AssignNumbers(_teamOdds);

        for (int i = 0; i < PicksSimulated; i++)
        {
            var winningCombination = _randomizerService.GetWinningNumbers();
            var winningTeam = teamNumbers.FirstOrDefault(x => x.HasNumberCombination(winningCombination));
            while (winningTeam == null)
            {
                winningCombination = _randomizerService.GetWinningNumbers();
                winningTeam = teamNumbers.FirstOrDefault(x => x.HasNumberCombination(winningCombination));
            }

            winners.Add(winningTeam);
            teamNumbers.RemoveAll(n => n.HasNumberCombination(winningCombination));
        }


        return winners;
    }
}
