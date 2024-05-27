using Core.Consts;
using Core.Models.Newsletter;
using Data.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User;

public class UserServingViewModel
{
    public UserServingViewModel() { }

    public UserServingViewModel(UserServing userMuscleMobility)
    {
        UserId = userMuscleMobility.UserId;
        Section = userMuscleMobility.Section;
        Count = userMuscleMobility.Count;
    }

    public Section Section { get; init; }

    public int UserId { get; init; }

    [Range(UserConsts.WeeklyServingsMin, UserConsts.WeeklyServingsMax)]
    public int Count { get; set; }
}