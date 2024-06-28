using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using Data.Entities.Recipe;
using Data.Entities.User;

namespace Data.Query;

public interface IRecipeCombo
{
    Recipe Recipe { get; }
    public int Scale { get; }
    IList<Nutrient> Nutrients { get; }
}

public static class Filters
{
    /// <summary>
    /// Make sure the exercise is for the correct workout type
    /// </summary>
    public static IQueryable<T> FilterSection<T>(IQueryable<T> query, Section? value) where T : IRecipeCombo
    {
        // Debug should be able to see all exercises.
        if (value.HasValue && value != Section.None && value != Section.Debug)
        {
            // Has any flag
            query = query.Where(vm => (vm.Recipe.Section & value.Value) != 0);
        }

        return query;
    }

    /// <summary>
    /// Filter down to these specific exercises
    /// </summary>
    public static IQueryable<T> FilterRecipes<T>(IQueryable<T> query, IList<int>? exerciseIds) where T : IRecipeCombo
    {
        if (exerciseIds != null)
        {
            query = query.Where(vm => exerciseIds.Contains(vm.Recipe.Id));
        }

        return query;
    }

    /// <summary>
    /// Make sure the exercise works a specific muscle group
    /// </summary>
    public static IQueryable<T> FilterNutrients<T>(IQueryable<T> query, Nutrients? nutrients, bool include) where T : IRecipeCombo
    {
        if (nutrients.HasValue && nutrients != Nutrients.None)
        {
            if (include)
            {
                query = query.Where(r => r.Recipe.RecipeIngredients.Any(i => (i.Ingredient.Nutrients.Any(n => nutrients.Value.HasFlag(n.Nutrients)))));
            }
            else
            {
                // If a recovery muscle is set, don't choose any exercises that work the injured muscle
                query = query.Where(r => r.Recipe.RecipeIngredients.All(i => (i.Ingredient.Nutrients.All(n => !nutrients.Value.HasFlag(n.Nutrients)))));
            }
        }

        return query;
    }

    /// <summary>
    ///     Filters exercises to whether they use certain equipment.
    /// </summary>
    public static IQueryable<T> FilterEquipmentIds<T>(IQueryable<T> query, Equipment? equipments) where T : IRecipeCombo
    {
        if (equipments.HasValue)
        {
            if (equipments == Equipment.None)
            {
                query = query.Where(i => i.Recipe.Equipment == Equipment.None);
            }
            else
            {
                // Has any flag
                query = query.Where(i => (i.Recipe.Equipment & equipments) != 0);
            }
        }

        return query;
    }
}
