namespace Web.ViewModels.User.Components;

public class CurrentFeastViewModel
{
    public Data.Entities.User.User User { get; init; } = null!;

    public string Token { get; init; } = null!;
}
