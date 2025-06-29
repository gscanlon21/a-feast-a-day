﻿using Core.Models.Newsletter;
using Data.Entities.Newsletter;
using Data.Entities.Recipe;
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

    public RecipeOptions(Section section, int? userId) : this(section)
    {
        UserId = userId;
    }

    public int? UserId { get; set; }

    public bool IgnorePrerequisites { get; set; }

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
    /// </summary>
    public void AddRecipes(IEnumerable<Recipe>? recipes)
    {
        if (recipes != null)
        {
            if (RecipeIds == null)
            {
                RecipeIds = recipes.ToDictionary(nv => nv.Id, nv => (int?)1);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }

    /// <summary>
    /// Only select these recipes.
    /// </summary>
    public void AddRecipes(IEnumerable<UserRecipe>? recipes)
    {
        if (recipes != null)
        {
            if (RecipeIds == null)
            {
                RecipeIds = recipes.ToDictionary(nv => nv.RecipeId, nv => (int?)1);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
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
                throw new NotImplementedException();
            }
        }
    }
}
