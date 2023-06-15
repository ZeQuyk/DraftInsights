using DraftInsights.NHLApi.Models;

namespace DraftInsights.NHLApi.Extensions;

internal static class StatsTypesExtensions
{
    internal static string GetStatsTypeString(this StatsTypes statsType)
    {
        return statsType switch
        {
            StatsTypes.CareerRegularSeason => "careerRegularSeason",
            StatsTypes.YearByYear => "yearByYear",
            _ => string.Empty,
        };
    }
}
