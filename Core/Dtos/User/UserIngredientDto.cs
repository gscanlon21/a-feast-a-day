using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Dtos.User;

[Table("user_ingredient")]
public class UserIngredientDto
{
    public int UserId { get; init; }

    [JsonIgnore]
    public virtual UserDto User { get; init; } = null!;

    public int IngredientId { get; set; }

    public int SubstituteIngredientId { get; set; }

    [JsonIgnore]
    public virtual IngredientDto Ingredient { get; init; } = null!;

    [JsonIgnore]
    public virtual IngredientDto SubstituteIngredient { get; init; } = null!;
}
