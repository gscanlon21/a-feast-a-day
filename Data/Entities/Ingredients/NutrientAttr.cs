using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Ingredients;

/// <summary>
/// Nutrients for an ingredient.
/// </summary>
/*[Table("nutrient_attr")]
[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public class NutrientAttr
{
    [Key]
    public int NutrientId { get; init; }

    public int? NutrientNumber { get; init; }

    [JsonIgnore, InverseProperty(nameof(Ingredients.Nutrient.NutrientAttr))]
    public virtual Nutrient? Nutrient { get; set; }

    public override int GetHashCode() => HashCode.Combine(NutrientId);
    public override bool Equals(object? obj) => obj is NutrientAttr other
        && other.NutrientId == NutrientId;

    private string GetDebuggerDisplay()
    {
        if (Nutrient != null)
        {
            return $"{Nutrient.Nutrients.GetSingleDisplayName()}";
        }

        return $"{NutrientId}";
    }
}*/
