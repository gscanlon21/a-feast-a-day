using Data.Entities.Newsletter;

namespace Web.Views.Shared.Components.PastFeasts;

public class PastFeastsViewModel
{
    public DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public IList<UserFeast> PastFeasts { get; init; } = null!;

    public Data.Entities.User.User User { get; init; } = null!;

    public string Token { get; init; } = null!;
}
