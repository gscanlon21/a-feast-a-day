﻿using Core.Consts;
using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.ManageRecipe;


public class ManageRecipeViewModel
{
    [ValidateNever]
    public required User.UserManageRecipeViewModel.Params Parameters { get; init; }

    [ValidateNever]
    public required Data.Entities.User.User User { get; init; }

    [ValidateNever]
    [Display(Name = "Recipe", Description = "Ignore this recipe.")]
    public required NewsletterRecipeDto Recipe { get; init; }

    [ValidateNever]
    [Display(Name = "Refreshes After", Description = "Refresh this recipe—the next feast will try and select a new recipe if available.")]
    public required Data.Entities.User.UserRecipe UserRecipe { get; init; }

    [Display(Name = "Notes")]
    public string? Notes { get; init; }

    [Required, Range(UserConsts.LagRefreshXWeeksMin, UserConsts.LagRefreshXWeeksMax)]
    [Display(Name = "Lag Refresh by X Weeks", Description = "Add a delay before this recipe is recycled from your workouts.")]
    public int LagRefreshXWeeks { get; init; }

    [Required, Range(UserConsts.PadRefreshXWeeksMin, UserConsts.PadRefreshXWeeksMax)]
    [Display(Name = "Pad Refresh by X Weeks", Description = "Add a delay before this recipe is recirculated back into your workouts.")]
    public int PadRefreshXWeeks { get; init; }

    public Verbosity RecipeVerbosity => Verbosity.Images;
}
