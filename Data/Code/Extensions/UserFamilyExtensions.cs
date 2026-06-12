using Core.Code.Attributes;
using Core.Models;
using Core.Models.Nutrients;
using Core.Models.User;
using Data.Entities.Users;

namespace Data.Code.Extensions;

public static class UserFamilyExtensions
{
    /// <summary>
    /// Returns the RDA as 100% and the TUL as a percentage of the RDA.
    /// If there is no TUL, uses <see cref="UserConsts.NutrientTargetTULDefault"/>%.
    /// </summary>
    public static DoubleRange DefaultRange(this ICollection<UserFamily> userFamilies, Nutrients nutrient)
    {
        var sumRDA = userFamilies.GramsOfRDATUL(null, nutrient, DRI.RDA).NullIfDefault() ?? 0;
        var sumTUL = userFamilies.GramsOfRDATUL(null, nutrient, DRI.TUL).NullIfDefault() ?? sumRDA * NutrientConsts.ScaleWhenNoTUL;

        return new DoubleRange(sumRDA * 7, sumTUL * 7);
    }

    /// <summary>
    /// Gets the total grams of RDA/TUL for a nutrient.
    /// FIXME: Need to pass in UserNutrient to actually adjust the nutrient targets.
    /// </summary>
    public static double GramsOfRDATUL(this IEnumerable<UserFamily> userFamilies, UserNutrient? userNutrient, Nutrients nutrient, DRI dri)
    {
        List<double> runningTotal = new(userFamilies.Count());
        var userFamiliesWithDRI = userFamilies.Select(f => new UserFamilyDRI(f, nutrient));
        foreach (var userDRI in userFamiliesWithDRI.OrderBy(x => x.DailyAllowance == null))
        {
            runningTotal.Add((userDRI.DailyAllowance, dri) switch
            {
                // Adjust nutrient targets when there's no DRI.
                (null, _) or => runningTotal.AverageOrDefault(),
                (_, DRI.RDA) when userDRI.DailyAllowance.RDA == null => runningTotal.AverageOrDefault(),
                (_, DRI.TUL) when userDRI.DailyAllowance.TUL == null => runningTotal.AverageOrDefault(),
                // Calculate the nutrient targets for a single family member and add it to the total.
                _ => userDRI.UserFamily.GramsOfRDATUL(userNutrient, userDRI.DailyAllowance, dri),
            });
        }

        return runningTotal.Sum();
    }

    /// <summary>
    /// Gets the total grams of RDA/TUL for a nutrient.
    /// </summary>
    public static double GramsOfRDATUL(this UserFamily userFamily, UserNutrient? userNutrient, DailyAllowanceAttribute dailyAllowance, DRI dri)
    {
        // Totals are used. Don't double up...
        var totalWeightKg = userFamily.Weight;
        var totalCaloriesPerDay = userFamily.CaloriesPerDay;
        var totalKCaloriesPerDay = totalCaloriesPerDay / 1000d;

        var maxValue = dri switch
        {
            DRI.RDA => dailyAllowance.RDA!.Value * (userNutrient?.RDAScale ?? 1),
            DRI.TUL => dailyAllowance.TUL!.Value * (userNutrient?.TULScale ?? 1),
            _ => throw new NotImplementedException(),
        };

        return (dailyAllowance.For, dailyAllowance.Measure, dailyAllowance.Multiplier) switch
        {
            // Percent of Kilocalorie/Energy both calculate the percent of total energy based on a macronutrient's calories / gram.
            (_, Measure.Percent, Multiplier.Kilocalorie) => maxValue * totalCaloriesPerDay / dailyAllowance.CaloriesPerGram / 100d,
            (_, Measure.Percent, Multiplier.TotalEnergy) => maxValue * totalCaloriesPerDay / dailyAllowance.CaloriesPerGram / 100d,
            (_, Measure.Percent, _) => throw new NotSupportedException("Use Multiplier.TotalEnergy or Multiplier.Kilocalorie"),
            (_, _, Multiplier.KilogramOfBodyweight) => totalWeightKg * dailyAllowance.Measure.ToGrams(maxValue),
            (_, _, Multiplier.Kilocalorie) => totalKCaloriesPerDay * dailyAllowance.Measure.ToGrams(maxValue),
            (_, _, Multiplier.TotalEnergy) => throw new NotSupportedException("Use Multiplier.Day"),
            (_, _, Multiplier.Day) => /* `raw count × ` */ dailyAllowance.Measure.ToGrams(maxValue),
            _ => throw new NotSupportedException("Missing measure/multiplier")
        };
    }
}
