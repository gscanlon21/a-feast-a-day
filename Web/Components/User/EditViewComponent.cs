using Core.Code.Extensions;
using Core.Consts;
using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.User;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class EditViewComponent(UserRepo userRepo, CoreContext context) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Edit";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User? user = null)
    {
        user ??= await userRepo.GetUser(UserConsts.DemoUser, UserConsts.DemoToken, allowDemoUser: true, includeServings: true, includeFamilies: true, includeIngredients: true);
        if (user == null)
        {
            return Content("");
        }

        var token = await userRepo.AddUserToken(user, durationDays: 1);
        return View("Edit", await PopulateUserEditViewModel(new UserEditViewModel(user, token)));
    }

    private async Task<UserEditViewModel> PopulateUserEditViewModel(UserEditViewModel viewModel)
    {
        viewModel.Ingredients = await context.Ingredients
            .Where(i => i.UserId == null || i.UserId == viewModel.User.Id)
            .OrderBy(i => i.Name)
            .ToListAsync();

        foreach (var muscleGroup in UserServing.MuscleTargets.Keys
            .OrderBy(mg => mg.GetSingleDisplayName(EnumExtensions.DisplayNameType.GroupName))
            .ThenBy(mg => mg.GetSingleDisplayName()))
        {
            var userMuscleMobility = viewModel.User.UserServings.SingleOrDefault(umm => umm.Section == muscleGroup);
            viewModel.UserServings.Add(userMuscleMobility != null ? new UserServingViewModel(userMuscleMobility) : new UserServingViewModel()
            {
                UserId = viewModel.User.Id,
                Section = muscleGroup,
                Count = UserServing.MuscleTargets.TryGetValue(muscleGroup, out int countTmp) ? countTmp : 0
            });
        }

        var rootIngredients = await context.Ingredients.Where(i => i.Children.Any()).ToListAsync();
        foreach (var rootIngredient in rootIngredients)
        {
            var existingIngredient = viewModel.User.UserIngredients.FirstOrDefault(i => i.IngredientId == rootIngredient.Id);
            viewModel.UserIngredients.Add(new UserIngredientViewModel()
            {
                UserId = viewModel.User.Id,
                IngredientId = rootIngredient.Id,
                SubstituteIngredientId = existingIngredient?.SubstituteIngredientId ?? rootIngredient.Id
            });
        }

        foreach (var family in viewModel.User.UserFamilies)
        {
            viewModel.UserFamilies.Add(new UserFamilyViewModel()
            {
                Person = family.Person,
                CaloriesPerDay = family.CaloriesPerDay,
                Weight = family.Weight,
                UserId = viewModel.User.Id,
            });
        }

        while (viewModel.UserFamilies.Count < 10)
        {
            viewModel.UserFamilies.Add(new UserFamilyViewModel()
            {
                UserId = viewModel.User.Id,
                Hide = viewModel.UserFamilies.Count > 0,
            });
        }

        return viewModel;
    }
}
