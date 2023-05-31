using DraftInsights.Core.Models;

namespace DraftInsights.Core.Services;

public interface ILotterySimulatorService
{
    Task<List<DraftPosition>> ComputeDraftOrderAsync();

    Task<List<DraftPosition>> GetInitialDraftOrderAsync();
}