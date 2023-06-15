namespace DraftInsights.Core.Models;

public abstract class PlayerBase : INhlPlayer
{
    public abstract int Id { get; }

    public abstract string FullName { get; }

    public virtual string Url => $"player/{Id}?name={FullName}";

    public virtual string AvatarUrl => $"https://cms.nhl.bamgrid.com/images/headshots/current/168x168/{Id}.jpg";
}
