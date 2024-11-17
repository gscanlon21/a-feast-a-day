using Data.Models.Newsletter;

namespace Web.Views.Shared.Components.PastFeasts;

public class PastFeastsViewModel
{
    public IList<PastFeast> PastFeasts { get; init; } = null!;

    public Data.Entities.User.User User { get; init; } = null!;

    public string Token { get; init; } = null!;
}
