using Core.Code.Attributes;
using Core.Code.Extensions;
using Core.Models.User;
using Data.Entities.User;

namespace Data.Code.Extensions;

public static class UserFamilyExtensions
{
    public static double NormalizedDailyAllowance(this DailyAllowanceAttribute dailyAllowance, IEnumerable<UserFamily> userFamilies)
    {
        var totalWeightKg = userFamilies.Sum(uf => uf.Weight);
        var totalKCaloriesPerDay = userFamilies.Sum(uf => uf.CaloriesPerDay) / 1000d;

        return ((dailyAllowance.For, dailyAllowance.Multiplier) switch
        {
            (_, Multiplier.Person) => dailyAllowance.Measure.ToGrams(dailyAllowance.RDA ?? 0),
            (_, Multiplier.KilogramOfBodyweight) => totalWeightKg * dailyAllowance.Measure.ToGrams(dailyAllowance.RDA ?? 0),
            (_, Multiplier.Kilocalorie) => totalKCaloriesPerDay * dailyAllowance.Measure.ToGrams(dailyAllowance.RDA ?? 0),
            _ => dailyAllowance.RDA
        } ?? 0) * userFamilies.Count();
    }
}
