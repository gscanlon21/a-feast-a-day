using Core.Code.Attributes;
using Core.Models.Nutrients;
using Data.Entities.Users;

namespace Data.Models.Users;

public class UserFamilyDRI
{
    public UserFamily UserFamily { get; private init; }
    public DailyAllowanceAttribute? DailyAllowance { get; private init; }

    public UserFamilyDRI(UserFamily userFamily, Nutrients nutrients)
    {
        DailyAllowance = nutrients.DailyAllowance(userFamily.Person);
        UserFamily = userFamily;
    }
}
