using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Recipes;

public class RecipesViewModel
{
    private readonly bool _formOpen;

    public IList<NewsletterRecipeDto> Recipes { get; set; } = null!;

    [Display(Name = "Name")]
    public string? Name { get; init; }

    [Display(Name = "Section")]
    public Section? Section { get; init; }

    [Display(Name = "Equipment")]
    public Equipment? Equipment { get; init; }

    [Display(Name = "Ingredient Name")]
    public string? Ingredient { get; init; }

    [Display(Name = "Max Prep Time (min)")]
    public int? PrepTime { get; init; }

    [Display(Name = "Max Cook Time (min)")]
    public int? CookTime { get; init; }

    [Display(Name = "Max Total Time (min)")]
    public int? TotalTime { get; init; }

    [Display(Name = "Minimum Servings", Description = "Serving-adjustable recipes are always included.")]
    public int? MinimumServings { get; init; }

    [ValidateNever]
    public Verbosity Verbosity => Verbosity.Debug;

    [ValidateNever]
    public bool FormOpen
    {
        get => _formOpen || Recipes?.Any() != true;
        // Needs to be settable for the 'Clear' btn.
        init => _formOpen = value;
    }

    [ValidateNever]
    public bool FormHasData =>
        !string.IsNullOrWhiteSpace(Name)
        || Section.HasValue
        || Equipment.HasValue;
}
