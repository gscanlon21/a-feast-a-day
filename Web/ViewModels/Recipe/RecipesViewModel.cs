using Core.Models.Newsletter;
using Core.Models.Recipe;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Recipe;

/// <summary>
/// Viewmodel for All.cshtml
/// </summary>
public class RecipesViewModel
{
    public RecipesViewModel() { }

    public IList<Lib.ViewModels.Newsletter.NewsletterRecipeViewModel> Recipes { get; set; } = null!;

    public Verbosity Verbosity => Verbosity.Debug;

    [Display(Name = "Exercise Name")]
    public string? Name { get; init; }

    [Display(Name = "Section")]
    public Section? Section { get; init; }

    [Display(Name = "Equipment")]
    public Equipment? Equipment { get; init; }

    public bool FormHasData =>
        !string.IsNullOrWhiteSpace(Name)
        || Section.HasValue
        || Equipment.HasValue;
}
