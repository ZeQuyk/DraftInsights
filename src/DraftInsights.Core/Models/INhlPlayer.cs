namespace DraftInsights.Core.Models;

public interface INhlPlayer
{
    public int Id { get; }

    public string FullName { get; }

    public string Url { get; }

    public string AvatarUrl { get; }
}
