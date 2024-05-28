using Core.Models.User;
using Data.Entities.User;

namespace Data.Models.Newsletter;

public class WorkoutContext
{
    public required DateOnly Date { get; init; }
    public User User { get; init; } = null!;
    public string Token { get; init; } = null!;
    public int DaysUntilNextNewsletter { get; init; } = 1;
    public required IDictionary<IngredientGroup, int?>? WeeklyMuscles { get; init; }
    public required double WeeklyMusclesWeeks { get; init; }
}
