using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

[Table("user_ingredient")]
public class UserIngredient
{
    [ForeignKey(nameof(Entities.User.User.Id))]
    public int UserId { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserIngredients))]
    public virtual User User { get; private init; } = null!;

    public int IngredientId { get; set; }

    public int SubstituteIngredientId { get; set; }

    [JsonIgnore, InverseProperty(nameof(Ingredient.UserIngredients))]
    public virtual Ingredient Ingredient { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Ingredient.UserSubstituteIngredients))]
    public virtual Ingredient SubstituteIngredient { get; private init; } = null!;
}
