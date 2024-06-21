using Core.Code.Attributes;
using Core.Code.Extensions;
using Core.Models.User;
using Data.Entities.User;

namespace Data.Code.Extensions;

public static class UserFamilyExtensions
{
    internal static double NormalizedDailyAllowanceTUL(this DailyAllowanceAttribute dailyAllowance, IEnumerable<UserFamily> userFamilies, double totalCalories)
    {
        var totalWeightKg = userFamilies.Sum(uf => uf.Weight);
        var totalKCaloriesPerDay = userFamilies.Sum(uf => uf.CaloriesPerDay) / 1000d;

        var maxValue = dailyAllowance.TUL ?? dailyAllowance.RDA ?? 0;
        return (dailyAllowance.For, dailyAllowance.Measure, dailyAllowance.Multiplier) switch
        {
            (_, Measure.Percent, _) => totalCalories / 100 * maxValue / dailyAllowance.CaloriesPerGram,
            (_, _, Multiplier.Person) => dailyAllowance.Measure.ToGrams(maxValue),
            (_, _, Multiplier.KilogramOfBodyweight) => totalWeightKg * dailyAllowance.Measure.ToGrams(maxValue),
            (_, _, Multiplier.Kilocalorie) => totalKCaloriesPerDay * dailyAllowance.Measure.ToGrams(maxValue),
            _ => maxValue
        } * userFamilies.Count();
    }
}
