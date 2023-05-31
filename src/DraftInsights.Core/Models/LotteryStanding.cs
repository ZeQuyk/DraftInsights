using DraftInsights.NHLApi.Models;

namespace DraftInsights.Core.Models;

public class LotteryStanding
{
    public LotteryStanding(Standing standing)
    {
        TeamRecords = standing.TeamRecords.OrderByDescending(r => r.IsPlayoffTeam()).ThenBy(r => r.LeagueRank).ToList();
    }

    public List<TeamRecord> TeamRecords { get; set; }

    public TeamRecord FindTeamRecord(int leagueRank) => TeamRecords.ElementAt(leagueRank - 1);
}
