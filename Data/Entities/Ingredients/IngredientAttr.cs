using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Ingredients;

/// <summary>
/// Ingredient's used in recipes.
/// 
/// <para>
/// The boiling point of most cooking oils is much higher than their smoke points. 
/// The boiling point of olive oil, for example, is around 300°C (572°F), 
/// ... which is hotter than the temperature of a pan on a typical residential range/cooktop.
/// With that said, alcohols and esters which make up the flavor and fragrance 
/// ... of the oil will have lower boiling points and will therefore evaporate.
/// That should not significantly alter the nutritional content of the oil. 
/// Furthermore, much of the perceived loss of oil is likely due to a combination 
/// ... of absorption of the oil into the items being fried, and also due to splatter. 
/// The latter cannot be easily quantified due to its connection with the cooking vessel and the technique of the cook.
/// </para>
/// </summary>
[Table("ingredient_attr")]
[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public class IngredientAttr
{
    [Key]
    public int IngredientId { get; init; }

    public int? FDC_ID { get; set; }

    /// <summary>
    /// Nutrient Database Number.
    /// </summary>
    public int? NDB_Number { get; set; }


    [JsonIgnore, InverseProperty(nameof(Ingredients.Ingredient.IngredientAttr))]
    public virtual Ingredient? Ingredient { get; set; }

    public override int GetHashCode() => HashCode.Combine(IngredientId);
    public override bool Equals(object? obj) => obj is IngredientAttr other
        && other.IngredientId == IngredientId;

    private string GetDebuggerDisplay()
    {
        if (Ingredient != null)
        {
            return $"{Ingredient.Name}";
        }

        return $"{IngredientId}";
    }
}
