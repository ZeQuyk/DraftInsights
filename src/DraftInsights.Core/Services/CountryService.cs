using Nager.Country;

namespace DraftInsights.Core.Services;

public class CountryService : ICountryService
{
    public string? GetCountryLogoUrl(string country3ISOCode)
    {
        var provider = new CountryProvider();
        if (!provider.TryGetCountry(country3ISOCode, out var country))
        {
            return null;
        }

        return $"https://flagsapi.com/{country.Alpha2Code}/flat/48.png";
    }
}
