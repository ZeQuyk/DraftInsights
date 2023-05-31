namespace DraftInsights.NHLApi.Models;

public class Standing
{
    public Standing()
    {
        TeamRecords = new List<TeamRecord>();
    }

    public List<TeamRecord> TeamRecords { get; set; }
}
