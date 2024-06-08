﻿using Core.Code.Extensions;
using Core.Consts;
using Core.Models.User;
using Data.Entities.User;

namespace Web.ViewModels.User.Components;


/// <summary>
/// Viewmodel for Nutrient.cshtml
/// </summary>
public class NutrientViewModel
{
    public required string Token { get; set; }
    public required Data.Entities.User.User User { get; set; }

    public int Weeks { get; set; }

    public double WeeksOfData { get; set; }

    public required IDictionary<Nutrients, int?> WeeklyVolume { get; set; }

    public Nutrients UsersWorkedMuscles { get; init; }

    // The max value (seconds of time-under-tension) of the range display
    public double MaxRangeValue => UserNutrient.NutrientTargets.Values.Max(r => r.End.Value);

    public MonthlyMuscle GetMuscleTarget(KeyValuePair<Nutrients, Range> defaultRange)
    {
        var userMuscleTarget = User.UserNutreints.Cast<UserNutrient?>().FirstOrDefault(um => um?.Nutrient == defaultRange.Key)?.Range ?? UserNutrient.NutrientTargets[defaultRange.Key];

        var sumRDA = User.UserFamilies.Average(f => defaultRange.Key.DailyAllowance(f.Person).RDA);
        var sumTUL = User.UserFamilies.Average(f => defaultRange.Key.DailyAllowance(f.Person).TUL) ?? sumRDA * 2;
        return new MonthlyMuscle()
        {
            IngredientGroup = defaultRange.Key,
            UserMuscleTarget = userMuscleTarget,
            Start = sumRDA / sumTUL * userMuscleTarget.Start.Value ?? 0,
            Middle = sumRDA / sumTUL * userMuscleTarget.End.Value ?? 0,
            End = sumRDA / sumTUL * userMuscleTarget.End.Value ?? 100,
            DefaultStart = sumRDA / sumTUL * defaultRange.Value.Start.Value ?? 0,
            DefaultEnd = sumRDA / sumTUL * defaultRange.Value.End.Value ?? 100,
            ValueInRange = Math.Min(101, (WeeklyVolume[defaultRange.Key] ?? 0) / MaxRangeValue * 100),
            ShowButtons = UsersWorkedMuscles.HasFlag(defaultRange.Key),
            Increment = sumRDA / sumTUL * UserConsts.IncrementNutrientTargetBy ?? UserConsts.IncrementNutrientTargetBy,
        };
    }

    public class MonthlyMuscle
    {
        public required Nutrients IngredientGroup { get; init; }
        public required bool ShowButtons { get; init; }
        public required Range UserMuscleTarget { get; init; }
        public required double Start { get; init; }
        public double Middle { get; init; }
        public double Increment { get; init; }
        public required double End { get; init; }
        public required double DefaultStart { get; init; }
        public required double DefaultEnd { get; init; }
        public required double ValueInRange { get; init; }
        public bool IsMinVolumeInRange => ValueInRange >= Start;
        public bool IsMaxVolumeInRange => ValueInRange <= End;

        public bool ShowDecreaseStart => ShowButtons && Start > 0;
        public bool ShowIncreaseStart => ShowButtons && Start + Increment < End - Increment;
        public bool ShowDecreaseEnd => ShowButtons && End - Increment > Start + Increment;
        public bool ShowIncreaseEnd => ShowButtons && End < 100;

        public string Color => (IsMinVolumeInRange, IsMaxVolumeInRange, ShowButtons) switch
        {
            // Max volume is out of range
            (_, false, true) => "orangered",
            // Min volume is out of range
            (false, _, true) => "darkorange",
            // Volume is in range
            _ => "limegreen",
        };
    }
}
