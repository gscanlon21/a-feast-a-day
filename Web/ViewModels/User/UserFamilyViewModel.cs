using Core.Models.User;
using Data.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User;

public class UserFamilyViewModel
{
    public int UserId { get; set; }

    [Range(UserFamily.Consts.WeightMin, UserFamily.Consts.WeightMax)]
    [Display(Name = "Weight (kg)")]
    public int Weight { get; init; } = UserFamily.Consts.WeightDefault;

    [Range(UserFamily.Consts.CaloriesPerDayMin, UserFamily.Consts.CaloriesPerDayMax)]
    [Display(Name = "Calories Per Day")]
    public int CaloriesPerDay { get; init; } = UserFamily.Consts.CaloriesPerDayDefault;

    [Display(Name = "Person")]
    public Person Person { get; init; }

    public bool Hide { get; set; }
}
