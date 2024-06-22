using Core.Dtos.User;

namespace Core.Dtos.Newsletter;

public class ShoppingListDto
{
    public required IList<RecipeIngredientDto> ShoppingList { get; init; } = [];

    /// <returns>Static hashcode.</returns>
    public override int GetHashCode() => ShoppingList.Sum(sl => sl.Id);

    public override bool Equals(object? obj) => obj is ShoppingListDto other
        && other.ShoppingList.SequenceEqual(ShoppingList);
}
