using Core.Code.Attributes;
using Data.Entities.Users;

namespace Core.Models.User;

public class UserFamilyDRI
{
    public UserFamily UserFamily { get; private init; }
    public DailyAllowanceAttribute? DailyAllowance { get; private init; }

    public UserFamilyDRI(UserFamily userFamily, Nutrients.Nutrients nutrients)
    {
        DailyAllowance = nutrients.DailyAllowance(userFamily.Person);
        UserFamily = userFamily;
    }
}
