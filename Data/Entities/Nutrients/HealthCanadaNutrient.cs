using Core.Models;
using Core.Models.Nutrients;
using Data.Entities.Ingredients;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Nutrients;

/// <summary>
/// Nutrients for an ingredient.
/// </summary>
[Table("hc_nutrient")]
[Index(nameof(IngredientId))]
[DebuggerDisplay("{Nutrients}: {Value} {Measure}")]
public class HealthCanadaNutrient
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

    public CanadaNutrients Nutrients { get; set; }

    public Measure Measure { get; set; }

    [Range(Consts.ValueMin, Consts.ValueMax)]
    public double Value { get; set; }

    /// <summary>
    /// Notes about the nutrient (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Ingredients.Ingredient.NutrientsCanada))]
    public virtual Ingredient? Ingredient { get; set; }

    #endregion


    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is HealthCanadaNutrient other
        && other.Id == Id;
}
