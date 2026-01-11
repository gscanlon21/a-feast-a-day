using Core.Models.User;
using Data.Entities.Ingredients;

namespace Data.Interfaces.Recipe;

public interface IRecipeIngredient
{
    bool IsCoarseCut { get; }

    /// <summary>
    /// This is the scaled quantity.
    /// </summary>
    double GetQuantity { get; }

    Measure GetMeasure { get; }

    Ingredient? GetIngredient { get; }

    int GetRecipeIngredientId { get; }

    double GetCookedScale { get; }
}
