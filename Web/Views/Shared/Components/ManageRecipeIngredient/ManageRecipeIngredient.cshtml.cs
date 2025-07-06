using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Web.Views.RecipeIngredient;

namespace Web.Views.Shared.Components.ManageRecipeIngredient;

public class ManageRecipeIngredientViewModel : IValidatableObject
{
    [ValidateNever]
    public required UserManageRecipeIngredientViewModel.Params Parameters { get; init; }

    [ValidateNever]
    public required Data.Entities.User.User User { get; init; }

    [ValidateNever, Display(ShortName = "Substitute", Name = "Substitute Ingredient")]
    public required Data.Entities.User.UserRecipeIngredient UserRecipeIngredient { get; init; }

    [ValidateNever, Display(Name = "Recipe Ingredient", Description = "Ignore this recipe's ingredient.")]
    public required Data.Entities.Recipe.RecipeIngredient RecipeIngredient { get; init; }

    /// <summary>
    /// Recipes that the user is able to select as an ingredient alternative.
    /// </summary>
    [ValidateNever]
    public required IList<Data.Entities.Recipe.Recipe> Recipes { get; init; }

    /// <summary>
    /// The ingredient's alternative ingredients.
    /// </summary>
    [ValidateNever]
    public required IList<IngredientDto> Ingredients { get; init; }

    /// <summary>
    /// Need a user context so the manage link is clickable and the user can un-ignore a recipe/ingredient.
    /// </summary>
    [ValidateNever]
    public required UserNewsletterDto UserNewsletter { get; init; }

    /// <summary>
    /// Don't allow ignoring non-optional ingredients if they aren't areadly ignored.
    /// </summary>
    [ValidateNever]
    public bool DenyIgnoringIngredient => !RecipeIngredient.Optional && !UserRecipeIngredient.Ignore;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (UserRecipeIngredient?.SubstituteIngredientId.HasValue == true && UserRecipeIngredient?.SubstituteRecipeId.HasValue == true)
        {
            yield return new ValidationResult($"Both Substitute Ingredient and Substitute Recipe cannot have values.", [nameof(UserRecipeIngredient)]);
        }
    }
}
