using Core.Dtos.Ingredient;
using Core.Dtos.User;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Web.Views.Ingredient;

namespace Web.Views.Shared.Components.ManageIngredient;

public class ManageIngredientViewModel : IValidatableObject
{
    [ValidateNever]
    public required UserManageIngredientViewModel.Params Parameters { get; init; }

    [ValidateNever]
    public required Data.Entities.User.User User { get; init; }

    [ValidateNever, Display(Name = "Ingredient", Description = "Ignore this ingredient.")]
    public required IngredientDto Ingredient { get; init; }

    [ValidateNever, Display(ShortName = "Substitute", Name = "Substitute Ingredient")]
    public required Data.Entities.User.UserIngredient UserIngredient { get; init; }

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

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (UserIngredient?.SubstituteIngredientId.HasValue == true && UserIngredient?.SubstituteRecipeId.HasValue == true)
        {
            yield return new ValidationResult($"Both Substitute Ingredient and Substitute Recipe cannot have values.", [nameof(UserIngredient)]);
        }
    }
}
