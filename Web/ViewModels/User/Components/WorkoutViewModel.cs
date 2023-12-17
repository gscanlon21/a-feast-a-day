namespace Web.ViewModels.User.Components;

public class WorkoutViewModel
{
    public Data.Entities.User.User User { get; init; } = null!;

    public string Token { get; init; } = null!;
}
