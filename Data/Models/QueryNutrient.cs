using Core.Models;
using Core.Models.Nutrients;
using Data.Entities.Ingredients;
using Data.Entities.Nutrients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class QueryNutrient
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

    public Nutrients Nutrients { get; set; }

    public Measure Measure { get; set; }

    [Range(Consts.ValueMin, Consts.ValueMax)]
    public double Value { get; set; }

    public DataSource DataSource { get; init; }

    /// <summary>
    /// Notes about the nutrient (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;


    #region Navigation Properties

    public virtual Ingredient? Ingredient { get; set; }

    //[JsonIgnore, InverseProperty(nameof(Ingredients.NutrientAttr.Nutrient))]
    //public virtual NutrientAttr? NutrientAttr { get; set; }

    #endregion


    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is USDANutrient other
        && other.Id == Id;
}