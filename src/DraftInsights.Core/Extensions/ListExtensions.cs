namespace DraftInsights.Core.Extensions;

public static class ListExtensions
{
    public static void Shuffle<T>(this List<T> list)
    {
        var random = new Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n--);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}
