using Core.Models.Newsletter;
using Data.Entities.Newsletter;
using Data.Entities.Recipe;

namespace Data.Query.Options;

public class RecipeOptions : IOptions
{
    private readonly Section _section;

    public RecipeOptions() { }

    public RecipeOptions(Section section)
    {
        _section = section;
    }

    /// <summary>
    /// RecipeId:Scale.
    /// </summary>
    public Dictionary<int, int>? RecipeIds { get; private set; }

    public void AddPastRecipes(ICollection<UserFeastRecipe> userFeastRecipes)
    {
        RecipeIds = userFeastRecipes
            .Where(nv => _section == nv.Section || _section == Section.None)
            .ToDictionary(nv => nv.RecipeId, nv => nv.Scale);
    }

    /// <summary>
    /// Exclude any variation of these exercises from being chosen.
    /// </summary>
    public void AddRecipes(IEnumerable<Recipe>? recipes)
    {
        if (recipes != null)
        {
            if (RecipeIds == null)
            {
                RecipeIds = recipes.ToDictionary(nv => nv.Id, nv => 1);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }

    /// <summary>
    /// Exclude any variation of these exercises from being chosen.
    /// </summary>
    public void AddRecipes(IEnumerable<KeyValuePair<int, int>>? recipeIds)
    {
        if (recipeIds != null)
        {
            if (RecipeIds == null)
            {
                RecipeIds = recipeIds.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
