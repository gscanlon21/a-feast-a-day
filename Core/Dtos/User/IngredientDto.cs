﻿using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Core.Dtos.User;

/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("ingredient")]
[DebuggerDisplay("{Name,nq}")]
public class IngredientDto
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public int? UserId { get; init; }

    public int? ParentId { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [Display(Name = "Allergens")]
    public Allergy Allergens { get; set; }

    /// <summary>
    /// Is a common household ingredient like salt and pepper.
    /// </summary>
    [Display(Name = "Skip Shopping List")]
    public bool SkipShoppingList { get; set; }

    [Display(Name = "Grams Per Serving")]
    public double GramsPerServing { get; set; }

    [Display(Name = "Calories Per Serving")]
    public double CaloriesPerServing { get; set; }

    [Display(Name = "Grams Per Measure")]
    public double GramsPerMeasure { get; set; }
    [Display(Name = "Default Measure")]
    public Measure DefaultMeasure { get; set; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    [Display(Name = "Notes")]
    public string? Notes { get; set; } = null;

    /// <summary>
    /// When was this ingredient last checked, for debug user.
    /// </summary>
    public DateOnly LastUpdated { get; set; }

    /// <summary>
    /// The base ingredient.
    /// </summary>
    [JsonIgnore]
    public virtual IngredientDto? Parent { get; init; } = null!;

    /// <summary>
    /// Substitute ingredients.
    /// </summary>
    public virtual ICollection<IngredientDto> Children { get; init; } = [];

    public string? DisabledReason { get; init; } = null;

    [JsonIgnore]
    public virtual UserDto? User { get; set; }

    [JsonInclude]
    public virtual List<RecipeIngredientDto> RecipeIngredients { get; init; } = null!;

    /// <summary>
    /// Nutrients per Serving Size (Grams).
    /// </summary>
    public virtual List<NutrientDto> Nutrients { get; set; } = [];

    [JsonIgnore]
    public virtual ICollection<UserDto> UserExclusions { get; init; } = [];

    [JsonIgnore]
    public virtual ICollection<UserIngredientDto> UserIngredients { get; init; } = [];

    [JsonIgnore]
    public virtual ICollection<UserIngredientDto> UserSubstituteIngredients { get; init; } = [];

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is IngredientDto other
        && other.Id == Id;

    [NotMapped]
    public Allergy[]? AllergenBinder
    {
        get => Enum.GetValues<Allergy>().Where(e => Allergens.HasFlag(e)).ToArray();
        set => Allergens = value?.Aggregate(Allergy.None, (a, e) => a | e) ?? Allergy.None;
    }
}
