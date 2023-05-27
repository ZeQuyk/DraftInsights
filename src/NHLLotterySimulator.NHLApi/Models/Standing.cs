namespace NHLLotterySimulator.NHLApi.Models;

public class Standing
{
    public Standing()
    {
        TeamRecords = new List<TeamRecord>();
    }

    public List<TeamRecord> TeamRecords { get; set; }

    public TeamRecord FindTeamRecord(int leagueRank)
        => TeamRecords.First(t => t.LeagueRank == leagueRank);
}
