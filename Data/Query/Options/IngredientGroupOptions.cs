using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Data.Query.Options;

public class IngredientGroupOptions : IOptions
{
    private int? _atLeastXIngredientGroupsPerRecipe;
    private int? _atLeastXUniqueIngredientGroupsPerRecipe;

    public IngredientGroupOptions() { }

    public IngredientGroupOptions(IList<Nutrient> muscleGroups, IDictionary<Nutrient, int> muscleTargets)
    {
        MuscleGroups = muscleGroups;
        MuscleTargets = muscleTargets;
    }

    /// <summary>
    /// Filters variations to only those that target these muscle groups.
    /// </summary>
    public IList<Nutrient> MuscleGroups { get; } = [];

    /// <summary>
    /// Filters variations to only those that target these muscle groups.
    /// </summary>
    public IDictionary<Nutrient, int> MuscleTargets { get; } = new Dictionary<Nutrient, int>();

    public int GetWorkedMuscleSum()
    {
        // Ignoring negative values because those aren't worked.
        return MuscleTargets.Where(mt => MuscleGroups.Contains(mt.Key)).Sum(mt => Math.Max(mt.Value, 0));
    }

    /// <summary>
    /// This says what (strengthening/secondary/stretching) muscles we should abide by when selecting variations.
    /// </summary>
    public Expression<Func<IRecipeCombo, Nutrient>> MuscleTarget { get; set; } = v => v.Recipe.Ingredients.Aggregate(Nutrient.None, (curr, next) => curr | (next.Ingredient.Nutrients));

    /// <summary>
    ///     Makes sure each variations works at least x unique muscle groups to be chosen.
    ///     
    ///     If no variations can be found, will drop x by 1 and look again until all muscle groups are accounted for.
    /// </summary>
    [Range(1, 9)]
    public int? AtLeastXUniqueIngredientGroupsPerRecipe
    {
        get => _atLeastXUniqueIngredientGroupsPerRecipe;
        set => _atLeastXUniqueIngredientGroupsPerRecipe = value;
    }

    /// <summary>
    /// Minimum value for AtLeastXUniqueMusclesPerRecipe.
    /// </summary>
    [Range(1, 9)]
    public int? AtLeastXIngredientGroupsPerRecipe
    {
        get => _atLeastXIngredientGroupsPerRecipe;
        set => _atLeastXIngredientGroupsPerRecipe = value;
    }
}