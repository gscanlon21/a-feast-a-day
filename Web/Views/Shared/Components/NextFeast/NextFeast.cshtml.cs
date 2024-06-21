using Core.Models.User;

namespace Web.Views.Shared.Components.NextFeast;

public class NextFeastViewModel
{
    public Days Today { get; init; }

    /// <summary>
    /// Negative if the next workout is in the process of sending.
    /// Otherwise the duration until the next workout starts sending.
    /// </summary>
    public TimeSpan? TimeUntilNextSend { get; init; }

    public Data.Entities.User.User User { get; init; } = null!;

    public string Token { get; init; } = null!;
}
