using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Nutrients;

/// <summary>
/// Nutrients for an ingredient.
/// </summary>
[Table("nutrient")]
[DebuggerDisplay("({Order}) {Key}: {Name}")]
public class Nutrient
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public int Order { get; set; }

    public string Key { get; set; } = null!;

    public string Name { get; set; } = null!;

    /// <summary>
    /// Notes about the nutrient (externally shown).
    /// </summary>
    public string? Notes { get; set; } = null;

    public DateOnly LastUpdated { get; set; } = DateHelpers.Today;


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(DietaryIntake.Nutrient))]
    public virtual List<DietaryIntake> DietaryIntakes { get; set; } = [];

    #endregion


    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Nutrient other
        && other.Id == Id;
}
