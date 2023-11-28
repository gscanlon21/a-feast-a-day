using Core.Models.Exercise;
using Core.Models.User;
using Data.Entities.Newsletter;
using Data.Entities.User;

namespace Data.Models.Newsletter;

public class WorkoutContext
{
    public User User { get; init; } = null!;
    public string Token { get; init; } = null!;
    public WorkoutRotation WorkoutRotation { get; init; } = null!;
    public MuscleGroups UserAllWorkedMuscles { get; init; }
    public bool NeedsDeload { get; init; }
    public TimeSpan TimeUntilDeload { get; init; }
    public IDictionary<MuscleGroups, int?>? WeeklyMuscles { get; init; }
    public double WeeklyMusclesWeeks { get; init; }
    public Frequency Frequency { get; init; }
}
