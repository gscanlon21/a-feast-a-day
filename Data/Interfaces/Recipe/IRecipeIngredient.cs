using Core.Models.User;
using Data.Entities.Ingredients;

namespace Data.Interfaces.Recipe;

public interface IRecipeIngredient
{
    /// <summary>
    /// This is the scaled quantity.
    /// </summary>
    double GetQuantity { get; }

    Measure GetMeasure { get; }

    Ingredient? GetIngredient { get; }

    /// <summary>
    /// This ingredient provides fewer nutrients than normal.
    /// </summary>
    bool IsCookedOff { get; }
}
