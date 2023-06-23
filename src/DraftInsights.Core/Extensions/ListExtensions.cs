namespace DraftInsights.Core.Extensions;

public static class ListExtensions
{
    public static void Shuffle<T>(this List<T> list)
    {
        var random = new Random();
        var n = list.Count;
        while (n > 1)
        {
            var k = random.Next(n--);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}
