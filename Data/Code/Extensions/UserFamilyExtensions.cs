using Core.Code.Attributes;
using Core.Models;
using Core.Models.Nutrients;
using Data.Entities.Users;

namespace Data.Code.Extensions;

public static class UserFamilyExtensions
{
    /// <summary>
    /// Returns the RDA as 100% and the TUL as a percentage of the RDA.
    /// If there is no TUL, uses <see cref="UserConsts.NutrientTargetTULDefault"/>%.
    /// </summary>
    public static Range DefaultRange(this ICollection<UserFamily> userFamilies, Nutrients nutrient)
    {
        var sumRDA = userFamilies.Where(f => nutrient.DailyAllowance(f.Person) != null).Average(f => nutrient.DailyAllowance(f.Person)!.RDA);
        var sumTUL = userFamilies.Where(f => nutrient.DailyAllowance(f.Person) != null).Average(f => nutrient.DailyAllowance(f.Person)!.TUL) ?? sumRDA * 2;
        var tulDefault = (sumTUL.HasValue && sumRDA.HasValue) ? (int)Math.Ceiling(sumTUL.Value / sumRDA.Value * 100) : UserConsts.NutrientTargetTULDefault;

        return new Range(UserConsts.NutrientTargetDefaultPercent, tulDefault);
    }

    public static double GramsOfRDATUL(this DailyAllowanceAttribute dailyAllowance, IEnumerable<UserFamily> userFamilies, bool tul = false)
    {
        var totalWeightKg = userFamilies.Sum(uf => uf.Weight);
        var totalCaloriesPerDay = userFamilies.Sum(uf => uf.CaloriesPerDay);
        var totalKCaloriesPerDay = totalCaloriesPerDay / 1000d;

        var maxValue = tul ? (dailyAllowance.TUL ?? dailyAllowance.RDA ?? 0) : (dailyAllowance.RDA ?? dailyAllowance.TUL ?? 0);
        return (dailyAllowance.For, dailyAllowance.Measure, dailyAllowance.Multiplier) switch
        {
            (_, Measure.Percent, _) => maxValue * totalCaloriesPerDay / dailyAllowance.CaloriesPerGram / 100d,
            (_, _, Multiplier.KilogramOfBodyweight) => totalWeightKg * dailyAllowance.Measure.ToGrams(maxValue),
            (_, _, Multiplier.Kilocalorie) => totalKCaloriesPerDay * dailyAllowance.Measure.ToGrams(maxValue),
            (_, _, Multiplier.Person) => dailyAllowance.Measure.ToGrams(maxValue),
            _ => maxValue
        } * userFamilies.Count();
    }
}
