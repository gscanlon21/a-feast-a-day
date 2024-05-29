using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Data.Query.Options;

public class NutrientOptions : IOptions
{
    private int? _atLeastXNutrientsPerRecipe;
    private int? _atLeastXUniqueNutrientsPerRecipe;

    public NutrientOptions() { }

    public NutrientOptions(IList<Nutrients> nutrients, IDictionary<Nutrients, int> nutrientTargets)
    {
        Nutrients = nutrients;
        NutrientTargets = nutrientTargets;
    }

    /// <summary>
    /// Filters variations to only those that target these muscle groups.
    /// </summary>
    public IList<Nutrients> Nutrients { get; } = [];

    /// <summary>
    /// Filters variations to only those that target these muscle groups.
    /// </summary>
    public IDictionary<Nutrients, int> NutrientTargets { get; } = new Dictionary<Nutrients, int>();

    public int GetWorkedNutrientsSum()
    {
        // Ignoring negative values because those aren't worked.
        return NutrientTargets.Where(mt => Nutrients.Contains(mt.Key)).Sum(mt => Math.Max(mt.Value, 0));
    }

    /// <summary>
    /// This says what (strengthening/secondary/stretching) muscles we should abide by when selecting variations.
    /// </summary>
    public Expression<Func<IRecipeCombo, Nutrients>> NutrientTarget { get; set; } = v => v.Recipe.Ingredients.Aggregate(Core.Models.User.Nutrients.None, (curr, next) => curr | (next.Ingredient.Nutrients.Aggregate(Core.Models.User.Nutrients.None, (c, n) => c | n.Nutrients)));

    /// <summary>
    ///     Makes sure each variations works at least x unique muscle groups to be chosen.
    ///     
    ///     If no variations can be found, will drop x by 1 and look again until all muscle groups are accounted for.
    /// </summary>
    [Range(1, 9)]
    public int? AtLeastXUniqueNutrientsPerRecipe
    {
        get => _atLeastXUniqueNutrientsPerRecipe;
        set => _atLeastXUniqueNutrientsPerRecipe = value;
    }

    /// <summary>
    /// Minimum value for AtLeastXUniqueMusclesPerRecipe.
    /// </summary>
    [Range(1, 9)]
    public int? AtLeastXNutrientsPerRecipe
    {
        get => _atLeastXNutrientsPerRecipe;
        set => _atLeastXNutrientsPerRecipe = value;
    }
}