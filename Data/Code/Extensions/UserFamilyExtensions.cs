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
        var sumRDA = userFamilies.Where(f => nutrient.DailyAllowance(f.Person) != null).Average(f => nutrient.DailyAllowance(f.Person)!.RDA);
        var sumTUL = userFamilies.Where(f => nutrient.DailyAllowance(f.Person) != null).Average(f => nutrient.DailyAllowance(f.Person)!.TUL) ?? sumRDA * 2;
        var tulDefault = (sumTUL.HasValue && sumRDA.HasValue) ? (sumTUL.Value / sumRDA.Value * 100) : UserConsts.NutrientTargetTULDefault;

        return new DoubleRange(UserConsts.NutrientTargetDefaultPercent, tulDefault);
    }

    /// <summary>
    /// Gets the total grams of RDA/TUL for a nutrient.
    /// </summary>
    public static double GramsOfRDATUL(this IEnumerable<UserFamily> userFamilies, Nutrients nutrient, bool tul)
    {
        List<double> runningTotal = new(userFamilies.Count());
        var userFamiliesWithDRI = userFamilies.Select(f => new UserFamilyDRI(f, nutrient));
        foreach (var userDRI in userFamiliesWithDRI.OrderBy(x => x.DailyAllowance == null))
        {
            // Make sure null is ordered last.
            if (userDRI.DailyAllowance == null)
            {
                // Adjust nutrient targets when there's no DRI.
                runningTotal.Add(runningTotal.AverageOrDefault());
            }
            else
            {
                // Calculate the nutrient targets for a single family member and add it to the total.
                runningTotal.Add(userDRI.UserFamily.GramsOfRDATUL(userDRI.DailyAllowance, tul: tul));
            }
        }

        return runningTotal.Sum();
    }

    /// <summary>
    /// Gets the total grams of RDA/TUL for a nutrient.
    /// </summary>
    public static double GramsOfRDATUL(this UserFamily userFamily, DailyAllowanceAttribute dailyAllowance, bool tul)
    {
        // Totals are used. Don't double up...
        var totalWeightKg = userFamily.Weight;
        var totalCaloriesPerDay = userFamily.CaloriesPerDay;
        var totalKCaloriesPerDay = totalCaloriesPerDay / 1000d;

        var maxValue = tul // TODO/FIXME: Test and redo all the conversion code. So very messy.
                ? (dailyAllowance.TUL ?? (dailyAllowance.RDA * NutrientConsts.RDAScaleWhenNoTUL) ?? 0)
                : (dailyAllowance.RDA ?? (dailyAllowance.TUL / NutrientConsts.RDAScaleWhenNoTUL) ?? 0);

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
