﻿using Core.Models.Newsletter;
using Lib.ViewModels.User;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User.Components;

public class IgnoredViewModel
{
    [Display(Name = "Ignored Exercises")]
    public IList<Lib.ViewModels.Newsletter.RecipeViewModel> IgnoredExercises { get; init; }

    [Display(Name = "Ignored Variations")]
    public IList<Lib.ViewModels.Newsletter.RecipeViewModel> IgnoredVariations { get; init; }

    public Verbosity Verbosity => Verbosity.Images;

    public UserNewsletterViewModel UserNewsletter { get; init; }
}
