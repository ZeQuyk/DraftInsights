﻿using DraftInsights.Core.Services;

var service = new LotterySimulatorService();
var teams = await service.ComputeDraftOrderAsync();

foreach (var team in teams)
{
    Console.WriteLine($"{team.Position} ({team.PositionDifference}) - {team.TeamRecord.Team!.Name} ({team.TeamRecord.LeagueRecord})");
}