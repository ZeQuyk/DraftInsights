using DraftInsights.Core.Models;
using DraftInsights.NHLApi.Models;
using DraftInsights.NHLApi.Services;

namespace DraftInsights.Core.Services;

public class LotterySimulatorService : ILotterySimulatorService
{
    private const int MaximumJump = 10;
    public const int PicksSimulated = 2;

    private readonly NumberRandomizerService _randomizerService;
    private readonly StandingsService _standingsService;
    private readonly List<TeamOdds> _teamOdds = new()
    {
        new TeamOdds(32, 0.185M),
        new TeamOdds(31, 0.135M),
        new TeamOdds(30, 0.115M),
        new TeamOdds(29, 0.095M),
        new TeamOdds(28, 0.085M),
        new TeamOdds(27, 0.075M),
        new TeamOdds(26, 0.065M),
        new TeamOdds(25, 0.06M),
        new TeamOdds(24, 0.05M),
        new TeamOdds(23, 0.035M),
        new TeamOdds(22, 0.03M),
        new TeamOdds(21, 0.025M),
        new TeamOdds(20, 0.02M),
        new TeamOdds(19, 0.015M),
        new TeamOdds(18, 0.005M),
        new TeamOdds(17, 0.005M),
    };

    public LotterySimulatorService()
    {
        _randomizerService = new NumberRandomizerService();
        _standingsService = new StandingsService();
    }

    public async Task<List<DraftPosition>> GetInitialDraftOrderAsync()
    {
        var standings = await _standingsService.GetStandingsAsync();

        return GenerateDraftPositions(new List<TeamLotteryNumbers>(), standings.NhlStandings).OrderBy(t => t.Position).ToList();
    }

    public async Task<List<DraftPosition>> ComputeDraftOrderAsync()
    {
        var standings = await _standingsService.GetStandingsAsync();
        var winners = ComputeLottery();

        return GenerateDraftPositions(winners, standings.NhlStandings).OrderBy(t => t.Position).ToList();
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

    private List<DraftPosition> GenerateDraftPositions(List<TeamLotteryNumbers> winners, Standing standings)
    {
        var positions = new List<DraftPosition>();
        var remainingPicks = Enumerable.Range(1, _teamOdds.Count).ToList();
        var lastPosition = standings.TeamRecords.Last().LeagueRank;

        // Winning teams move up, the rest move down accordingly
        foreach (var winner in winners)
        {
            var team = standings.FindTeamRecord(winner.LeagueRank);
            var initialPosition = lastPosition - winner.LeagueRank + 1;
            var newPosition = winners.IndexOf(winner) + 1;
            if (initialPosition > MaximumJump + 1)
            {
                newPosition = initialPosition - MaximumJump;
            }

            positions.Add(new(newPosition, initialPosition, team));
            remainingPicks.Remove(newPosition);
        }

        foreach (var team in _teamOdds)
        {
            if (winners.Any(w => w.LeagueRank == team.LeagueRank))
            {
                continue;
            }

            var teamRecord = standings.FindTeamRecord(team.LeagueRank);
            var initialPosition = lastPosition - teamRecord.LeagueRank + 1;
            var pick = remainingPicks.First();
            positions.Add(new(pick, initialPosition, teamRecord));
            remainingPicks.Remove(pick);
        }

        return positions;
    }
}
