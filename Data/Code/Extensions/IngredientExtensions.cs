using Data.Entities.User;

namespace Data.Code.Extensions;

public static class IngredientExtensions
{
    public static Ingredient SubstitutedIngredient(this Ingredient ingredient, IList<UserIngredient> substitutes)
    {
        var substitute = substitutes.FirstOrDefault(s => s.IngredientId == ingredient.Id);
        return substitute?.SubstituteIngredient ?? ingredient;
    }
}
