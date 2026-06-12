using Data.Code.Extensions;
using Data.Entities.Users;

namespace Web.Views.Shared.Components.Nutrient;

public class NutrientViewModel
{
    public required string Token { get; init; }
    public required Data.Entities.Users.User User { get; init; }

    public required int Weeks { get; init; }

    public required double WeeksOfData { get; init; }

    public required IList<Nutrients> UsersWorkedNutrients { get; init; } = [];

    public required IDictionary<Nutrients, double?> WeeklyVolume { get; init; }

    public NutrientTarget GetNutrientTarget(Nutrients nutrient)
    {
        var defaultRange = User.UserFamilies.DefaultRange(nutrient);
        var userNutrientTarget = User.UserNutrients.Cast<UserNutrient?>().FirstOrDefault(um => um?.Nutrient == nutrient);

        var userNutrient = User.UserNutrients.FirstOrDefault(un => un.Nutrient == nutrient);
        var sumRDA = User.UserFamilies.GramsOfRDATUL(userNutrient, nutrient, DRI.RDA).NullIfDefault() * 7;
        var sumTUL = User.UserFamilies.GramsOfRDATUL(userNutrient, nutrient, DRI.TUL).NullIfDefault() * 7;

        // Show default nutrient targets when backfilling data.
        var defaultStart = Math.Max(defaultRange.Start.Value / defaultRange.End.Value * 100, 0);
        var userValueInRange = Math.Min(101, (WeeklyVolume[nutrient] ?? 0) / defaultRange.End.Value * 100d);
        var valueInRange = User.CreatedDate == DateHelpers.Today ? 0 : userValueInRange;

        return new NutrientTarget(nutrient)
        {
            ValueInRange = valueInRange,
            DefaultStart = defaultStart,
            Start = userNutrientTarget switch
            {
                not null => 100 * userNutrientTarget.RDAScale,
                null => defaultStart,
            },
            End = userNutrientTarget switch
            {
                not null => 100 * userNutrientTarget.TULScale,
                null => 100,
            },
            ShowButtons = UsersWorkedNutrients.Contains(nutrient),
        };
    }

    public class NutrientTarget
    {
        public NutrientTarget(Nutrients nutrientGroup)
        {
            NutrientGroup = nutrientGroup;
        }

        public Nutrients NutrientGroup { get; }

        public required double Start { get; init; }
        public required double End { get; init; }

        public required double DefaultStart { get; init; }
        public double DefaultEnd { get; init; } = 100;

        public required double ValueInRange { get; init; }
        public bool IsMinVolumeInRange => ValueInRange >= Start;
        public bool IsMaxVolumeInRange => ValueInRange <= End;

        public required bool ShowButtons { get; init; }

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
