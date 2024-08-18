using Data.Entities.Newsletter;

namespace Web.Views.Shared.Components.PastFeasts;

public class PastFeastsViewModel
{
    public IList<UserFeast> PastFeasts { get; init; } = null!;

    public Data.Entities.User.User User { get; init; } = null!;

    public string Token { get; init; } = null!;
}
