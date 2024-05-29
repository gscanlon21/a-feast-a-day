using Core.Consts;
using Core.Models.User;
using Data.Entities.User;

namespace Web.ViewModels.User.Components;


/// <summary>
/// Viewmodel for MonthlyMuscles.cshtml
/// </summary>
public class IngredientGroupViewModel
{
    public required string Token { get; set; }
    public required Data.Entities.User.User User { get; set; }

    public int Weeks { get; set; }

    public double WeeksOfData { get; set; }

    public required IDictionary<Nutrients, int?> WeeklyVolume { get; set; }

    public Nutrients UsersWorkedMuscles { get; init; }

    // The max value (seconds of time-under-tension) of the range display
    public double MaxRangeValue => 2 * UserNutrient.MuscleTargets.Values.Max(r => r.End.Value);

    public MonthlyMuscle GetMuscleTarget(KeyValuePair<Nutrients, Range> defaultRange)
    {
        var userMuscleTarget = User.UserIngredientGroups.Cast<UserNutrient?>().FirstOrDefault(um => um?.Nutrient == defaultRange.Key)?.Range ?? UserNutrient.MuscleTargets[defaultRange.Key];

        return new MonthlyMuscle()
        {
            IngredientGroup = defaultRange.Key,
            UserMuscleTarget = userMuscleTarget,
            Start = userMuscleTarget.Start.Value / MaxRangeValue * 100,
            Middle = (userMuscleTarget.Start.Value + UserConsts.IncrementMuscleTargetBy) / MaxRangeValue * 100,
            End = userMuscleTarget.End.Value / MaxRangeValue * 100,
            DefaultStart = defaultRange.Value.Start.Value / MaxRangeValue * 100,
            DefaultEnd = defaultRange.Value.End.Value / MaxRangeValue * 100,
            ValueInRange = Math.Min(101, (WeeklyVolume[defaultRange.Key] ?? 0) / MaxRangeValue * 100),
            IsMinVolumeInRange = WeeklyVolume[defaultRange.Key] >= userMuscleTarget.Start.Value,
            IsMaxVolumeInRange = WeeklyVolume[defaultRange.Key] <= userMuscleTarget.End.Value,
            ShowButtons = UsersWorkedMuscles.HasFlag(defaultRange.Key),
        };
    }

    public class MonthlyMuscle
    {
        public required Nutrients IngredientGroup { get; init; }
        public required bool ShowButtons { get; init; }
        public required Range UserMuscleTarget { get; init; }
        public required double Start { get; init; }
        public double Middle { get; init; }
        public required double End { get; init; }
        public required double DefaultStart { get; init; }
        public required double DefaultEnd { get; init; }
        public required double ValueInRange { get; init; }
        public required bool IsMinVolumeInRange { get; init; }
        public required bool IsMaxVolumeInRange { get; init; }
    }
}
