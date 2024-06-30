using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Dtos.User;

[Table("user_ingredient")]
public class UserIngredientDto
{
    public int UserId { get; init; }

    public int IngredientId { get; set; }

    public int SubstituteIngredientId { get; set; }
}
