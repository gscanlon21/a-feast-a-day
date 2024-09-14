using Core.Dtos.Ingredient;
using Core.Models.Newsletter;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.ManageIngredient;

public class ManageIngredientViewModel : IValidatableObject
{
    [ValidateNever]
    public required User.UserManageIngredientViewModel.Params Parameters { get; init; }

    [ValidateNever]
    public required Data.Entities.User.User User { get; init; }

    [ValidateNever, Display(Name = "Ingredient", Description = "Ignore this ingredient.")]
    public required IngredientDto Ingredient { get; init; }

    [ValidateNever, Display(ShortName = "Substitute", Name = "Substitute Ingredient")]
    public required Data.Entities.User.UserIngredient UserIngredient { get; init; }

    [ValidateNever]
    public required IList<Data.Entities.Recipe.Recipe> Recipes { get; init; }

    [ValidateNever]
    public required IList<Data.Entities.Ingredient.Ingredient> Ingredients { get; init; }

    public Verbosity RecipeVerbosity => Verbosity.Images;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (UserIngredient?.SubstituteIngredientId.HasValue == true && UserIngredient?.SubstituteRecipeId.HasValue == true)
        {
            yield return new ValidationResult($"Both Substitute Ingredient and Substitute Recipe cannot have values.", [nameof(UserIngredient)]);
        }
    }
}
