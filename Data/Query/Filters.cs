using Core.Models.Newsletter;
using Core.Models.User;
using Data.Entities.User;
using System.Linq.Expressions;
using System.Reflection;

namespace Data.Query;

public interface IRecipeCombo
{
    Recipe Recipe { get; }
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
    public static IQueryable<T> FilterNutrients<T>(IQueryable<T> query, Nutrient? nutrients, bool include) where T : IRecipeCombo
    {
        if (nutrients.HasValue && nutrients != Nutrient.None)
        {
            if (include)
            {
                query = query.Where(r => r.Recipe.Ingredients.Any(i => (i.Ingredient.Nutrients & nutrients) != 0));
            }
            else
            {
                // If a recovery muscle is set, don't choose any exercises that work the injured muscle
                query = query.Where(r => r.Recipe.Ingredients.All(i => (i.Ingredient.Nutrients & nutrients) == 0));
            }
        }

        return query;
    }
}
