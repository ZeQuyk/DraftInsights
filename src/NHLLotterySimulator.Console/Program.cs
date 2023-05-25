using NHLLotterySimulator.Core.Models;
using NHLLotterySimulator.Core.Services;

var teamOdds = new List<TeamOdds>
{
    new TeamOdds("Anaheim", 0.185M),
    new TeamOdds("Columbus", 0.135M),
    new TeamOdds("Chicago", 0.115M),
    new TeamOdds("San Jose", 0.095M),
    new TeamOdds("Montreal", 0.085M),
    new TeamOdds("Arizona", 0.075M),
    new TeamOdds("Philadelphia", 0.065M),
    new TeamOdds("Washington", 0.06M),
    new TeamOdds("Detroit", 0.05M),
    new TeamOdds("St. Louis", 0.035M),
    new TeamOdds("Vancouver", 0.03M),
    new TeamOdds("Arizona via Ottawa", 0.025M),
    new TeamOdds("Buffalo", 0.02M),
    new TeamOdds("Pittsburgh", 0.015M),
    new TeamOdds("Nashville", 0.005M),
    new TeamOdds("Calgary", 0.005M),
};

var service = new LotterySimulatorService();
var winners = service.GetWinners();
foreach (var winningTeam in winners)
{
    Console.WriteLine($"{winningTeam.Team} wins the lottery!");
}
