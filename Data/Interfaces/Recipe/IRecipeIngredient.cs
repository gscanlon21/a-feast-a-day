using Core.Models.User;
using Data.Entities.Ingredient;

namespace Data.Interfaces.Recipe;

public interface IRecipeIngredient
{
    double GetQuantity { get; }
    Measure GetMeasure { get; }
    Ingredient? GetIngredient { get; }
}
