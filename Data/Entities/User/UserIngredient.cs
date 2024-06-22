using System.ComponentModel.DataAnnotations;
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

    [Display(Name = "Substitute Ingredient", ShortName = "Substitute")]
    public int SubstituteIngredientId { get; set; }

    public bool Ignore { get; set; }

    [JsonIgnore, InverseProperty(nameof(Ingredient.UserIngredients))]
    public virtual Ingredient Ingredient { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Ingredient.UserSubstituteIngredients))]
    public virtual Ingredient SubstituteIngredient { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(UserId, IngredientId);

    public override bool Equals(object? obj) => obj is UserIngredient other
        && other.UserId == UserId
        && other.IngredientId == IngredientId;
}
