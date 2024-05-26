using Core.Models.Exercise;
using Core.Models.Newsletter;
using Core.Models.User;
using Lib.ViewModels.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Ingredient;

/// <summary>
/// Viewmodel for All.cshtml
/// </summary>
public class IngredientsViewModel
{
    public IngredientsViewModel() { }

    public IList<IngredientViewModel> Ingredients { get; set; } = null!;

    public Verbosity Verbosity => Verbosity.Debug;

    [Display(Name = "Exercise Name")]
    public string? Name { get; init; }

    [Display(Name = "Section")]
    public Section? Section { get; init; }

    public bool FormHasData =>
        !string.IsNullOrWhiteSpace(Name)
        || Section.HasValue;
}
