using Core.Code.Attributes;
using Core.Code.Extensions;
using Core.Models.User;
using Data.Entities.User;

namespace Data.Code.Extensions;

public static class UserFamilyExtensions
{
    public static double GramsOfRDATUL(this DailyAllowanceAttribute dailyAllowance, IEnumerable<UserFamily> userFamilies, bool tul = false)
    {
        var totalWeightKg = userFamilies.Sum(uf => uf.Weight);
        var totalCaloriesPerDay = userFamilies.Sum(uf => uf.CaloriesPerDay);
        var totalKCaloriesPerDay = totalCaloriesPerDay / 1000d;

        var maxValue = tul ? (dailyAllowance.TUL ?? dailyAllowance.RDA ?? 0) : (dailyAllowance.RDA ?? dailyAllowance.TUL ?? 0);
        return (dailyAllowance.For, dailyAllowance.Measure, dailyAllowance.Multiplier) switch
        {
            (_, Measure.Percent, _) => maxValue * totalCaloriesPerDay / dailyAllowance.CaloriesPerGram / 100d,
            (_, _, Multiplier.Person) => dailyAllowance.Measure.ToGramsOrDefault(maxValue),
            (_, _, Multiplier.KilogramOfBodyweight) => totalWeightKg * dailyAllowance.Measure.ToGramsOrDefault(maxValue),
            (_, _, Multiplier.Kilocalorie) => totalKCaloriesPerDay * dailyAllowance.Measure.ToGramsOrDefault(maxValue),
            _ => maxValue
        } * userFamilies.Count();
    }
}
