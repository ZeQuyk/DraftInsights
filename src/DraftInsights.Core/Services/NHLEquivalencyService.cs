namespace DraftInsights.Core.Services;

public class NHLEquivalencyService : INHLEquivalencyService
{
    private readonly Dictionary<string, double> LeagueEquivalencies = new(StringComparer.InvariantCultureIgnoreCase)
    {
        { "KHL", 0.804 },
        { "Czechia", 0.583 },
        { "SHL", 0.566 },
        { "NL", 0.459 },
        { "Liiga", 0.441 },
        { "AHL", 0.486 },
        { "DEL", 0.352 },
        { "HockeyAllsvenskan", 0.351 },
        { "Slovakia", 0.295 },
        { "VHL", 0.328 },
        { "NCAA", 0.333 },
        { "H-East", 0.393 },
        { "OHL", 0.323 },
        { "USHL", 0.143 },
        { "NTDP", 0.143 },
        { "MHL", 0.143 },
        { "WHL", 0.302 },
        { "QMJHL", 0.284 },
        { "BCHL", 0.080 },
        { "AJHL", 0.062 },
    };

    public int? GetNhlPointsEquivalent(string? league, int points, int gamesPlayed)
    {
        if (string.IsNullOrEmpty(league) || gamesPlayed == 0 || !LeagueEquivalencies.TryGetValue(league, out var equivalency))
        {
            return null;
        }

        var pointsPerGame = (double)points / gamesPlayed;
        var nhlPointsPerGame = pointsPerGame * equivalency;

        return (int)Math.Round(nhlPointsPerGame * 82);
    }
}
