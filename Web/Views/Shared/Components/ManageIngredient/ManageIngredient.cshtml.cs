using Core.Dtos.Ingredient;
using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.ManageIngredient;


public class ManageIngredientViewModel
{
    public required User.UserManageIngredientViewModel.Params Parameters { get; init; }

    public required Data.Entities.User.User User { get; init; }

    [Display(Name = "Ingredient", Description = "Ignore this ingredient.")]
    public required IngredientDto Ingredient { get; init; }

    [Display(ShortName = "Substitute", Name = "Substitute Ingredient")]
    public required Data.Entities.User.UserIngredient UserIngredient { get; init; }

    public Verbosity RecipeVerbosity => Verbosity.Images;

    public required IList<Data.Entities.Recipe.Recipe> Recipes { get; init; }
    public required IList<Data.Entities.Ingredient.Ingredient> Ingredients { get; init; }
}
