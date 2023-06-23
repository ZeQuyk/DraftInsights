using System.Text.Json;

namespace DraftInsights.NHLApi.Serialization;

internal static class JsonSerializer
{
    private static JsonSerializerOptions? _serializerOptions;

    public static T? Deserialize<T>(string json)
        => System.Text.Json.JsonSerializer.Deserialize<T>(json, GetSerializerOptions());

    private static JsonSerializerOptions GetSerializerOptions()
    {
        _serializerOptions ??= new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        return _serializerOptions;
    }
}
