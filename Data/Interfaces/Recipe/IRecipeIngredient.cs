using Core.Models.User;
using Data.Entities.Ingredient;

namespace Data.Interfaces.Recipe;

public interface IRecipeIngredient
{
    /// <summary>
    /// This is the scaled quantity.
    /// </summary>
    double GetQuantity { get; }

    Measure GetMeasure { get; }

    Ingredient? GetIngredient { get; }
}
