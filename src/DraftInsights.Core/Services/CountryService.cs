using Nager.Country;

namespace DraftInsights.Core.Services;

public class CountryService : ICountryService
{
    public string? GetCountryLogoUrl(string country3ISOCode)
    {
        var provider = new CountryProvider();

        var country = provider.GetCountry(country3ISOCode);
        if (country is null)
        {
            return null;
        }

        return $"https://flagsapi.com/{country.Alpha2Code}/flat/48.png";
    }
}
