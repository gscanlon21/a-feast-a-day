using Core.Models.Newsletter;
using Data.Entities.Newsletter;
using Data.Entities.User;

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
    /// Will not choose any exercises that fall in this list.
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
    public void AddExercises(IEnumerable<Recipe>? exercises)
    {
        if (exercises != null)
        {
            if (RecipeIds == null)
            {
                RecipeIds = exercises.ToDictionary(nv => nv.Id, nv => 1);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
