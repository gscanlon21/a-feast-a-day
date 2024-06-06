using Core.Code.Attributes;
using Core.Models.User;
using Data.Entities.User;

namespace Data.Code.Extensions;

public static class UserFamilyExtensions
{
    public static double NormalizedDailyAllowance(this DailyAllowanceAttribute dailyAllowance, IEnumerable<UserFamily> userFamilies)
    {
        var totalWeight = userFamilies.Sum(uf => uf.Weight);
        var totalCaloriesPerDay = userFamilies.Sum(uf => uf.CaloriesPerDay);

        return ((dailyAllowance.For, dailyAllowance.Multiplier) switch
        {
            (Person.All, Multiplier.Person) => dailyAllowance.RDA,
            _ => dailyAllowance.RDA
        } ?? 0) * userFamilies.Count();
    }
}
