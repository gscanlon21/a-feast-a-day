using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;
using Data.Entities.Ingredients;
using Data.Entities.Recipes;
using Microsoft.EntityFrameworkCore;

namespace Data.Query;

public interface IRecipeCombo
{
    Recipe Recipe { get; }
    IList<Nutrient> Nutrients { get; }
}

public static class Filters
{
    /// <summary>
    /// Filter down to recipes containing this ingredient.
    /// </summary>
    public static IQueryable<T> FilterIngredient<T>(IQueryable<T> query, string? ingredient) where T : IRecipeCombo
    {
        if (string.IsNullOrWhiteSpace(ingredient))
        {
            return query;
        }

        return query.Where(vm => vm.Recipe.RecipeIngredients.Any(ri => EF.Functions.ILike(ri.Ingredient.Name, $"%{ingredient}%")));
    }

    /// <summary>
    /// Make sure the recipe's prep time is below a threshold.
    /// </summary>
    public static IQueryable<T> FilterPrepTime<T>(IQueryable<T> query, int? value) where T : IRecipeCombo
    {
        if (!value.HasValue)
        {
            return query;
        }

        return query.Where(vm => vm.Recipe.PrepTime <= value);
    }

    /// <summary>
    /// Make sure the recipe's cook time is below a threshold.
    /// </summary>
    public static IQueryable<T> FilterCookTime<T>(IQueryable<T> query, int? value) where T : IRecipeCombo
    {
        if (!value.HasValue)
        {
            return query;
        }

        return query.Where(vm => vm.Recipe.CookTime <= value);
    }

    /// <summary>
    /// Make sure the recipe's total time is below a threshold.
    /// </summary>
    public static IQueryable<T> FilterTotalTime<T>(IQueryable<T> query, int? value) where T : IRecipeCombo
    {
        if (!value.HasValue)
        {
            return query;
        }

        return query.Where(vm => (vm.Recipe.PrepTime + vm.Recipe.CookTime) <= value);
    }

    /// <summary>
    /// Make sure the recipe's servings is above a threshold.
    /// </summary>
    public static IQueryable<T> FilterServings<T>(IQueryable<T> query, int? value) where T : IRecipeCombo
    {
        if (!value.HasValue)
        {
            return query;
        }

        return query.Where(vm => vm.Recipe.Servings >= value || vm.Recipe.AdjustableServings);
    }

    /// <summary>
    /// Make sure the recipe is for the correct section.
    /// </summary>
    public static IQueryable<T> FilterSection<T>(IQueryable<T> query, Section? value) where T : IRecipeCombo
    {
        // Debug should be able to see all recipes. None means no filter is applied.
        if (!value.HasValue || value == Section.None || value == Section.Debug)
        {
            return query;
        }

        // Prep recipes use base.
        return value == Section.Prep
            ? query.Where(vm => vm.Recipe.BaseRecipe) // Has any flag:
            : query.Where(vm => (vm.Recipe.Section & value.Value) != 0);
    }

    /// <summary>
    /// Filter down to these specific recipes.
    /// </summary>
    public static IQueryable<T> FilterRecipes<T>(IQueryable<T> query, ICollection<int>? recipeIds) where T : IRecipeCombo
    {
        if (recipeIds != null)
        {
            query = query.Where(vm => recipeIds.Contains(vm.Recipe.Id));
        }

        return query;
    }

    /// <summary>
    /// Make sure the recipe works a specific nutrient.
    /// </summary>
    public static IQueryable<T> FilterNutrients<T>(IQueryable<T> query, Nutrients? nutrients, bool include) where T : IRecipeCombo
    {
        if (!nutrients.HasValue || nutrients == Nutrients.None || nutrients == Nutrients.All)
        {
            return query;
        }

        if (include)
        {
            return query.Where(r => r.Recipe.RecipeIngredients.Any(i => i.Ingredient.Nutrients.Any(n => nutrients.Value.HasFlag(n.Nutrients))));
        }
        else
        {
            return query.Where(r => r.Recipe.RecipeIngredients.All(i => i.Ingredient.Nutrients.All(n => !nutrients.Value.HasFlag(n.Nutrients))));
        }
    }

    /// <summary>
    /// Filters recipes to whether they use certain equipment.
    /// </summary>
    public static IQueryable<T> FilterEquipment<T>(IQueryable<T> query, Equipment? equipment) where T : IRecipeCombo
    {
        if (equipment.HasValue)
        {
            if (equipment == Equipment.None)
            {
                query = query.Where(r => r.Recipe.Instructions.All(i => i.Equipment == Equipment.None));
            }
            else
            {
                query = query.Where(r => r.Recipe.Instructions.All(i =>
                    i.Equipment == Equipment.None // Has an flag:
                    || (i.Equipment & equipment.Value) != 0
                ));
            }
        }

        return query;
    }
}
