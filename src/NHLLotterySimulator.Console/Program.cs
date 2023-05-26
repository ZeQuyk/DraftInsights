using NHLLotterySimulator.Core.Services;

var service = new LotterySimulatorService();
var teams = service.ComputeDraftOrder();

foreach (var team in teams)
{
    Console.WriteLine($"{team.position} - {team.team}");
}