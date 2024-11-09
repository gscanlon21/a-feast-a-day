using Core.Consts;
using Core.Models.User;
using Data.Entities.User;

namespace Web.Views.Shared.Components.Nutrient;

public class NutrientViewModel
{
    public required string Token { get; set; }
    public required Data.Entities.User.User User { get; set; }

    public int Weeks { get; set; }

    public double WeeksOfData { get; set; }

    public Nutrients UsersWorkedNutrients { get; init; }

    public required IDictionary<Nutrients, double?> WeeklyVolume { get; set; }

    public NutrientTarget AllNutrientTarget => new()
    {
        NutrientGroup = Nutrients.All,
        ShowButtons = true,
        Start = 0,
        End = 100,
        Middle = 50,
        DefaultStart = 0,
        DefaultEnd = 100,
        ValueInRange = 50,
    };

    public NutrientTarget GetNutrientTarget(Nutrients nutrient)
    {
        var defaultRange = nutrient.DefaultRange();
        var userNutrientTarget = User.UserNutrients.Cast<UserNutrient?>().FirstOrDefault(um => um?.Nutrient == nutrient)?.Range ?? defaultRange;

        var sumRDA = User.UserFamilies.Average(f => nutrient.DailyAllowance(f.Person).RDA);
        var sumTUL = User.UserFamilies.Average(f => nutrient.DailyAllowance(f.Person).TUL) ?? sumRDA * 2;
        var start = sumRDA / sumTUL * userNutrientTarget.Start.Value ?? 0;
        return new NutrientTarget()
        {
            NutrientGroup = nutrient,
            Start = start,
            Middle = sumRDA / sumTUL * 100 ?? 0,
            End = sumRDA / sumTUL * userNutrientTarget.End.Value ?? 100,
            DefaultStart = sumRDA / sumTUL * defaultRange.Start.Value ?? 0,
            DefaultEnd = sumRDA / sumTUL * defaultRange.End.Value ?? 100,
            ValueInRange = sumRDA.HasValue ? Math.Min(101, (WeeklyVolume[nutrient] ?? 0) / 100d * start)
                : Math.Min(101, WeeklyVolume[nutrient] ?? 0),
            ShowButtons = UsersWorkedNutrients.HasFlag(nutrient),
            Increment = sumRDA / sumTUL * UserConsts.IncrementNutrientTargetBy ?? UserConsts.IncrementNutrientTargetBy,
        };
    }

    public class NutrientTarget
    {
        public required Nutrients NutrientGroup { get; init; }

        public required double Start { get; init; }
        /// <summary>
        /// The RDA as a percent of the TUL.
        /// </summary>
        public double Middle { get; init; }
        public required double End { get; init; }

        public required double DefaultStart { get; init; }
        public required double DefaultEnd { get; init; }

        public required double ValueInRange { get; init; }
        public bool IsMinVolumeInRange => ValueInRange >= Start;
        public bool IsMaxVolumeInRange => ValueInRange <= End;

        public double Increment { get; init; }
        public required bool ShowButtons { get; init; }
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
