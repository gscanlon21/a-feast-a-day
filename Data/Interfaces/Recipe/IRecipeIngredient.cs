using Data.Entities.Ingredients;

namespace Data.Interfaces.Recipe;

public interface IRecipeIngredient
{
    bool IsCoarseCut { get; }

    /// <summary>
    /// This is the scaled quantity.
    /// </summary>
    double GetGramsUsed { get; }

    Ingredient? GetIngredient { get; }

    double GetCookedScale { get; }
}
