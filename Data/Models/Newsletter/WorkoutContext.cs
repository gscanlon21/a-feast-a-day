using Data.Entities.User;

namespace Data.Models.Newsletter;

public class WorkoutContext
{
    public User User { get; init; } = null!;
    public string Token { get; init; } = null!;
}
