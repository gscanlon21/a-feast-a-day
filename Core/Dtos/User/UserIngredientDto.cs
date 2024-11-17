namespace Core.Dtos.User;

public class UserIngredientDto
{
    public int UserId { get; init; }

    public int IngredientId { get; set; }

    public int SubstituteIngredientId { get; set; }
}
