using DraftInsights.Core.Services;
using DraftInsights.NHLApi.Extensions;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddScoped<INumberRandomizerService, NumberRandomizerService>();
services.AddScoped<ILotterySimulatorService, LotterySimulatorService>();
services.AddMudServices();
services.AddNhlApi();
services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();