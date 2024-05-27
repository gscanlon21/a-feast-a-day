﻿using Core.Models.User;
using Data.Entities.User;

namespace Data.Query.Options;

public class ExclusionOptions : IOptions
{
    /// <summary>
    /// Will not choose any exercises that fall in this list.
    /// </summary>
    public List<int> RecipeIds = [];

    /// <summary>
    /// Will not choose any variations that fall in this list.
    /// </summary>
    public Allergy Allergens = Allergy.None;

    /// <summary>
    /// Exclude any variation of these exercises from being chosen.
    /// </summary>
    public void AddExcludeExercises(IEnumerable<UserRecipe>? exercises)
    {
        if (exercises != null)
        {
            RecipeIds.AddRange(exercises.Select(e => e.Id));
        }
    }

    /// <summary>
    /// Exclude any variations from being chosen that are a part of these exercise groups.
    /// </summary>
    public void AddExcludeGroups(IEnumerable<UserRecipe>? exercises)
    {
        if (exercises != null)
        {
            Allergens = exercises.Aggregate(Allergens, (c, n) => c | n.Allergens);
        }
    }

    /// <summary>
    /// Exclude any variations from being chosen that are a part of these exercise groups.
    /// </summary>
    public void AddExcludeGroups(Allergy allergens)
    {
        Allergens |= allergens;
    }
}