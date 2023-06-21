namespace DraftInsights.Core.Services;

public interface ICountryService
{
    string? GetCountryLogoUrl(string country3ISOCode);
}