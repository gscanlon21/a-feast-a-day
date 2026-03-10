using Core.Models;
using Core.Models.Nutrients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Models;

[DebuggerDisplay("{Nutrients}: {Value} {Measure}")]
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


    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is QueryNutrient other
        && other.Id == Id;
}