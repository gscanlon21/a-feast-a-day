namespace Web.Views.Shared.Components.CurrentFeast;

public class CurrentFeastViewModel
{
    public Data.Entities.User.User User { get; init; } = null!;

    public string Token { get; init; } = null!;
}
