using DraftInsights.NHLApi.Clients;
using DraftInsights.NHLApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DraftInsights.NHLApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNhlApi(this IServiceCollection services)
        {
            return services
                .AddScoped<INhlStatsClient, NhlStatsClient>()
                .AddScoped<INhlRecordsClient, NhlRecordsClient>()
                .AddScoped<INHLService, NHLService>();
        }
    }
}
