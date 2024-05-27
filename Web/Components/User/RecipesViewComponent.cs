﻿using Data;
using Data.Dtos.Newsletter;
using Data.Query.Builders;
using Data.Repos;
using Lib.ViewModels.Newsletter;
using Lib.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code;
using Web.ViewModels.User.Components;

namespace Web.Components.User;


/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class RecipesViewComponent(CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory) : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "Recipes";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        // Need a user context so the manage link is clickable and the user can un-ignore an exercise/variation.
        var userNewsletter = user.AsType<UserNewsletterViewModel, Data.Entities.User.User>()!;
        userNewsletter.Token = await userRepo.AddUserToken(user, durationDays: 1);


        var userRecipes = await context.UserRecipes.Where(r => r.UserId == user.Id).ToListAsync();
        var recipes = (await new QueryBuilder()
            // Include disabled recipes.
            .WithUser(user, ignoreIgnored: true, ignoreMissingEquipment: true, uniqueExercises: false)
            .WithExercises(x =>
            {
                x.AddExercises(userRecipes);
            })
            .Build()
            .Query(serviceScopeFactory))
            .Select(r => new RecipeDto(r)
            .AsType<NewsletterRecipeViewModel, RecipeDto>()!)
            .DistinctBy(vm => vm.Recipe)
            .ToList();

        return View("Recipes", new RecipesViewModel()
        {
            Recipes = recipes,
            UserNewsletter = userNewsletter,
        });
    }
}
