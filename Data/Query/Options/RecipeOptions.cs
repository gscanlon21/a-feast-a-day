using Core.Models.Newsletter;
using Data.Entities.Newsletter;
using Data.Entities.Recipes;
using Data.Entities.Users;

namespace Data.Query.Options;

public class RecipeOptions : IOptions
{
    private readonly Section _section;

    public RecipeOptions() { }

    public RecipeOptions(Section section)
    {
        _section = section;
    }

    public bool IgnorePrepRecipes { get; set; }

    /// <summary>
    /// RecipeId:Scale.
    /// </summary>
    public Dictionary<int, int?>? RecipeIds { get; private set; }

    public void AddPastRecipes(ICollection<UserFeastRecipe> userFeastRecipes)
    {
        RecipeIds = userFeastRecipes.Where(ufr => _section == ufr.Section || _section == Section.None)
            .GroupBy(ufr => ufr.RecipeId).ToDictionary(g => g.Key, g => (int?)g.Sum(ufr => ufr.Scale));
    }

    /// <summary>
    /// Only select these recipes.
    /// Don't pass in a scale so prep recipes go off of user servings.
    /// </summary>
    public void AddRecipes(IEnumerable<UserRecipe>? recipes)
    {
        AddRecipes(recipes?.ToDictionary(nv => nv.RecipeId, nv => (int?)null));
    }

    /// <summary>
    /// Only select these recipes.
    /// Don't pass in a scale so prep recipes go off of user servings.
    /// </summary>
    public void AddRecipes(IEnumerable<Recipe>? recipes)
    {
        AddRecipes(recipes?.ToDictionary(nv => nv.Id, nv => (int?)null));
    }

    /// <summary>
    /// Only select these recipes.
    /// </summary>
    public void AddRecipes(Dictionary<int, int?>? recipeIds)
    {
        if (recipeIds != null)
        {
            if (RecipeIds == null)
            {
                RecipeIds = recipeIds;
            }
            else
            {
                foreach (var kvp in recipeIds)
                {
                    RecipeIds.TryAdd(kvp.Key, kvp.Value);
                }
            }
        }
    }
}
