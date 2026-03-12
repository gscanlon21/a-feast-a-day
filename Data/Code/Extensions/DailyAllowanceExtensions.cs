using Core.Code.Attributes;
using Core.Models;
using Core.Models.Nutrients;
using Data.Entities.Users;

namespace Data.Code.Extensions;

public static class DailyAllowanceExtensions
{
    /// <summary>
    /// TODO/FIXME: Test and redo all the conversion code. So very messy.
    /// </summary>
    public static double GramsOfRDATUL(this DailyAllowanceAttribute dailyAllowance, IEnumerable<UserFamily> userFamilies, bool tul = false)
    {
        var totalWeightKg = userFamilies.Sum(uf => uf.Weight);
        var totalCaloriesPerDay = userFamilies.Sum(uf => uf.CaloriesPerDay);
        var totalKCaloriesPerDay = totalCaloriesPerDay / 1000d;

        // TODO/FIXME: Test and redo all the conversion code. So very messy.
        var maxValue = tul ? (dailyAllowance.TUL ?? dailyAllowance.RDA ?? 0) : (dailyAllowance.RDA ?? dailyAllowance.TUL ?? 0);
        return (dailyAllowance.For, dailyAllowance.Measure, dailyAllowance.Multiplier) switch
        {
            // Percent of Kilocalorie/Energy both calculate the percent of total energy based on a macronutrient's calories / gram.
            (_, Measure.Percent, Multiplier.Kilocalorie) => maxValue * totalCaloriesPerDay / dailyAllowance.CaloriesPerGram / 100d,
            (_, Measure.Percent, Multiplier.TotalEnergy) => maxValue * totalCaloriesPerDay / dailyAllowance.CaloriesPerGram / 100d,
            (_, Measure.Percent, _) => throw new NotSupportedException("Use Multiplier.TotalEnergy or Multiplier.Kilocalorie"),
            (_, _, Multiplier.KilogramOfBodyweight) => totalWeightKg * dailyAllowance.Measure.ToGrams(maxValue),
            (_, _, Multiplier.Kilocalorie) => totalKCaloriesPerDay * dailyAllowance.Measure.ToGrams(maxValue),
            (_, _, Multiplier.TotalEnergy) => throw new NotSupportedException("Use Multiplier.Day"),
            (_, _, Multiplier.Day) => dailyAllowance.Measure.ToGrams(maxValue),
            _ => throw new NotSupportedException("Missing measure/multiplier")
        } * userFamilies.Count();
    }
}
