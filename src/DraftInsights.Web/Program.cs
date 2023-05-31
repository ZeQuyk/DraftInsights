using DraftInsights.Core.Services;
using DraftInsights.Web.Data;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddSingleton<WeatherForecastService, WeatherForecastService>();
services.AddScoped<INumberRandomizerService, NumberRandomizerService>();
services.AddScoped<ILotterySimulatorService, LotterySimulatorService>();
services.AddMudServices();

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