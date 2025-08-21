﻿using Core.Dtos.Newsletter;
using Core.Dtos.User;
using Core.Models.User;
using Data.Entities.User;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.RecipeIngredient;

public class UserManageRecipeIngredientViewModel
{
    public required string Token { get; init; }

    public required Data.Entities.User.User User { get; init; }

    [Display(ShortName = "Substitute", Name = "Substitute Ingredient")]
    public required UserRecipeIngredientViewModel UserRecipeIngredient { get; init; }

    [Display(Name = "Recipe Ingredient", Description = "Ignore this recipe's ingredient.")]
    public required Data.Entities.Recipe.RecipeIngredient RecipeIngredient { get; init; }

    /// <summary>
    /// Recipes that the user is able to select as an ingredient alternative.
    /// </summary>
    public required IList<Data.Entities.Recipe.Recipe> Recipes { get; init; }

    public required IList<NewsletterRecipeDto> PrepRecipes { get; init; }
    public required IList<NewsletterRecipeDto> AltRecipes { get; init; }

    public required NewsletterRecipeDto Recipe { get; init; }

    /// <summary>
    /// The ingredient's alternative ingredients.
    /// </summary>
    public required IList<Data.Entities.Ingredient.Ingredient> Ingredients { get; init; }

    /// <summary>
    /// Need a user context so the manage link is clickable and the user can un-ignore a recipe/ingredient.
    /// </summary>
    public required UserNewsletterDto UserNewsletter { get; init; }

    /// <summary>
    /// Don't allow ignoring non-optional ingredients if they aren't areadly ignored.
    /// </summary>
    public bool DenyIgnoringIngredient => !RecipeIngredient.Optional && !UserRecipeIngredient.Ignore;

    public bool? WasUpdated { get; init; }
}

public class UserRecipeIngredientViewModel : IValidatableObject
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public UserRecipeIngredientViewModel() { }

    public UserRecipeIngredientViewModel(UserRecipeIngredient userRecipeIngredient)
    {
        Notes = userRecipeIngredient.Notes;
        Ignore = userRecipeIngredient.Ignore;
        Measure = userRecipeIngredient.Measure;
        QuantityNumerator = userRecipeIngredient.QuantityNumerator;
        QuantityDenominator = userRecipeIngredient.QuantityDenominator;
        SubstituteIngredientId = userRecipeIngredient.SubstituteIngredientId;
        SubstituteRecipeId = userRecipeIngredient.SubstituteRecipeId;
    }

    [Display(Name = "Measure")]
    public Measure? Measure { get; set; }

    [Display(Name = "Quantity")]
    [Range(RecipeConsts.QuantityNumeratorMin, RecipeConsts.QuantityNumeratorMax)]
    public int? QuantityNumerator { get; set; }

    [Display(Name = "Quantity")]
    [Range(RecipeConsts.QuantityDenominatorMin, RecipeConsts.QuantityDenominatorMax)]
    public int? QuantityDenominator { get; set; }

    [Display(Name = "Substitute Ingredient")]
    public int? SubstituteIngredientId { get; set; }

    [Display(Name = "or Substitute Recipe")]
    public int? SubstituteRecipeId { get; set; }

    public string? Notes { get; set; }

    [Required]
    public bool Ignore { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (SubstituteIngredientId.HasValue == true && SubstituteRecipeId.HasValue == true)
        {
            yield return new ValidationResult($"Both Substitute Ingredient and Substitute Recipe cannot have values.", [nameof(UserRecipeIngredient)]);
        }

        if (QuantityNumerator.HasValue && !QuantityDenominator.HasValue)
        {
            yield return new ValidationResult($"Quantity's denominator must have a value if Quantity's numerator is set.", [nameof(QuantityDenominator)]);
        }

        if (QuantityDenominator.HasValue && !QuantityNumerator.HasValue)
        {
            yield return new ValidationResult($"Quantity's numerator must have a value if Quantity's denominator is set.", [nameof(QuantityNumerator)]);
        }

        if (QuantityNumerator.HasValue && QuantityDenominator.HasValue && !Measure.HasValue)
        {
            yield return new ValidationResult($"Measure must have a value if Quantity is set.", [nameof(QuantityNumerator)]);
        }
    }
}
