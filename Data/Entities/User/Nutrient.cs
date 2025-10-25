using Core.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// Nutrients for an ingredient.
/// </summary>
[Table("nutrient")]
[Index(nameof(IngredientId))]
[DebuggerDisplay("{Nutrients}: {Value} {Measure}")]
public class Nutrient
{
    public class Consts
    {
        public const double ValueMin = 0;
        public const double ValueStep = .1;
        public const double ValueMax = 100000;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public int IngredientId { get; init; }

    /// <summary>
    /// If it has atleast 10% RDA per serving.
    /// </summary>
    public Nutrients Nutrients { get; set; }

    public Measure Measure { get; set; }

    [Range(Consts.ValueMin, Consts.ValueMax)]
    public double Value { get; set; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    [JsonIgnore, InverseProperty(nameof(Entities.Ingredient.Ingredient.Nutrients))]
    public virtual Ingredient.Ingredient? Ingredient { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Nutrient other
        && other.Id == Id;

    [NotMapped]
    public Nutrients[]? NutrientBinder
    {
        get => Enum.GetValues<Nutrients>().Where(e => Nutrients.HasFlag(e)).ToArray();
        set => Nutrients = value?.Aggregate(Nutrients.None, (a, e) => a | e) ?? Nutrients.None;
    }
}
