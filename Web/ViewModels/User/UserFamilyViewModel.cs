using Core.Models.User;
using Data.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User;

public class UserFamilyViewModel
{
    public int UserId { get; set; }

    [Range(UserFamily.Consts.WeightMin, UserFamily.Consts.WeightMax)]
    public int Weight { get; init; } = UserFamily.Consts.WeightDefault;

    [Range(UserFamily.Consts.CaloriesPerDayMin, UserFamily.Consts.CaloriesPerDayMax)]
    public int CaloriesPerDay { get; init; } = UserFamily.Consts.CaloriesPerDayDefault;

    public Person Person { get; init; }

    public bool Hide { get; set; }
}
