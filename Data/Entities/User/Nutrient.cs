using Core.Models.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("nutrient"), Comment("Recipes listed on the website")]
[DebuggerDisplay("{Nutrients}: {Measure} - {Value}")]
public class Nutrient
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

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    public string? DisabledReason { get; private init; } = null;

    [JsonIgnore, InverseProperty(nameof(Entities.User.Ingredient.Nutrients))]
    public virtual Ingredient? Ingredient { get; set; }

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
