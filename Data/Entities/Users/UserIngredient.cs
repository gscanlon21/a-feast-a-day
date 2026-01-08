using Data.Entities.Ingredients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

[Table("user_ingredient")]
[DebuggerDisplay("User {UserId}; Ingredient {IngredientId}")]
public class UserIngredient
{
    [Required]
    public int UserId { get; init; }

    [Required]
    public int IngredientId { get; set; }

    public string? Notes { get; set; }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Users.User.UserIngredients))]
    public virtual User User { get; private init; } = null!;

    [JsonIgnore, InverseProperty(nameof(Ingredient.UserIngredients))]
    public virtual Ingredient Ingredient { get; private init; } = null!;

    #endregion Navigation Properties


    public override int GetHashCode() => HashCode.Combine(UserId, IngredientId);
    public override bool Equals(object? obj) => obj is UserIngredient other
        && other.IngredientId == IngredientId
        && other.UserId == UserId;
}
