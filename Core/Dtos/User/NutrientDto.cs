﻿using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Core.Dtos.User;


/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("nutrient")]
[DebuggerDisplay("{Nutrients}: {Measure} - {Value}")]
public class NutrientDto
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public int? IngredientId { get; init; }

    /// <summary>
    /// If it has atleast 10% RDA per serving.
    /// </summary>
    public Nutrients Nutrients { get; set; }

    public Measure Measure { get; set; }

    public double Value { get; set; }

    public bool Synthetic { get; set; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    public string? DisabledReason { get; init; } = null;

    [JsonIgnore]
    public virtual IngredientDto? Ingredient { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is NutrientDto other
        && other.Id == Id;

    [NotMapped]
    public Nutrients[]? NutrientBinder
    {
        get => Enum.GetValues<Nutrients>().Where(e => Nutrients.HasFlag(e)).ToArray();
        set => Nutrients = value?.Aggregate(Nutrients.None, (a, e) => a | e) ?? Nutrients.None;
    }
}