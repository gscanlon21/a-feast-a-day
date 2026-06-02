using Core.Models.Nutrients;
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
}
