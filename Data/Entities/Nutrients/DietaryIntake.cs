using Core.Models;
using Core.Models.Nutrients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Nutrients;

[Table("dietary_intake")]
[DebuggerDisplay("{Key}: {Min}-{Max} {Measure}/{Multiplier}")]
public class DietaryIntake
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public int NutrientId { get; init; }

    public double? Min { get; set; }

    public double? Max { get; set; }

    public Person Person { get; set; }

    public Measure Measure { get; set; }

    public Multiplier Multiplier { get; set; }

    public double CaloriesPerGram { get; set; }

    public DateOnly LastUpdated { get; set; } = DateHelpers.Today;

    public string Source { get; set; } = null!;

    public string? Notes { get; set; }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Nutrients.Nutrient.DietaryIntakes))]
    public virtual Nutrient? Nutrient { get; set; }

    #endregion


    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is DietaryIntake other
        && other.Id == Id;
}
