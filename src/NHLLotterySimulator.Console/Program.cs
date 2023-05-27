using NHLLotterySimulator.Core.Services;

var service = new LotterySimulatorService();
var teams = await service.ComputeDraftOrderAsync();

foreach (var team in teams)
{
    Console.WriteLine($"{team.Position} - {team.TeamRecord.Team!.Name} ({team.TeamRecord.LeagueRecord})");
}