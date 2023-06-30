namespace DraftInsights.Core.Services;

public interface INHLEquivalencyService
{
    int? GetNhlPointsEquivalent(string? league, int points, int gamesPlayed);
}