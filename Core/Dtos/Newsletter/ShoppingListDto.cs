using Core.Dtos.User;

namespace Core.Dtos.Newsletter;

public class ShoppingListDto
{
    public required IList<RecipeIngredientDto> ShoppingList { get; init; } = [];

    public override int GetHashCode() => HashCode.Combine(ShoppingList);

    public override bool Equals(object? obj) => obj is ShoppingListDto other
        && other.ShoppingList.SequenceEqual(ShoppingList);
}
