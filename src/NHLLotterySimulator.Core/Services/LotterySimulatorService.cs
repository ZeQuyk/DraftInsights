using NHLLotterySimulator.Core.Models;

namespace NHLLotterySimulator.Core.Services;

public class LotterySimulatorService
{
    private const int MaximumJump = 10;
    public const int PicksSimulated = 2;

    private readonly NumberRandomizerService _randomizerService;    
    private readonly List<TeamOdds> _teamOdds = new()
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

    public List<DraftPosition> ComputeDraftOrder()
    {
        var winners = ComputeLottery();
        
        return GenerateDraftPositions(winners).OrderBy(t => t.Position).ToList();
    }

    private List<TeamLotteryNumbers> ComputeLottery()
    {
        var winners = new List<TeamLotteryNumbers>();
        var teamNumbers = _randomizerService.AssignNumbers(_teamOdds);

        for (int i = 0; i < PicksSimulated; i++)
        {
            var winningCombination = _randomizerService.DrawWinningCombination();
            var winningTeam = teamNumbers.FirstOrDefault(x => x.HasNumberCombination(winningCombination));
            while (winningTeam == null)
            {
                winningCombination = _randomizerService.DrawWinningCombination();
                winningTeam = teamNumbers.FirstOrDefault(x => x.HasNumberCombination(winningCombination));
            }

            winners.Add(winningTeam);
            teamNumbers.RemoveAll(n => n.HasNumberCombination(winningCombination));
        }

        return winners;
    }

    private List<DraftPosition> GenerateDraftPositions(List<TeamLotteryNumbers> winners) 
    {
        var positions = new List<DraftPosition>();
        var remainingPicks = Enumerable.Range(1, _teamOdds.Count).ToList();

        // Winning teams move up, the rest move down accordingly
        foreach (var winner in winners)
        {
            var initialPosition = _teamOdds.IndexOf(_teamOdds.First(t => t.Team.Equals(winner.Team, StringComparison.InvariantCultureIgnoreCase))) + 1;
            var newPosition = winners.IndexOf(winner) + 1;
            if (initialPosition > MaximumJump + 1)
            {
                newPosition = initialPosition - MaximumJump;
            }

            positions.Add(new(newPosition, winner.Team));
            remainingPicks.Remove(newPosition);
        }

        foreach (var team in _teamOdds)
        {
            if (winners.Any(w => w.Team.Equals(team.Team, StringComparison.InvariantCultureIgnoreCase)))
            {
                continue;
            }

            var pick = remainingPicks.First();
            positions.Add(new(pick, team.Team));
            remainingPicks.Remove(pick);
        }

        return positions;
    }
}
