using Core.Models.User;
using System.ComponentModel.DataAnnotations;

namespace Data.Query.Options;

public class NutrientOptions : IOptions
{
    private int? _AtLeastXNutrientsPerRecipe;

    public NutrientOptions() { }

    public NutrientOptions(IList<Nutrients> nutrients, IDictionary<Nutrients, double> nutrientTargetsRDA, IDictionary<Nutrients, double> nutrientTargetsTUL)
    {
        Nutrients = nutrients;
        NutrientTargetsRDA = nutrientTargetsRDA;
        NutrientTargetsTUL = nutrientTargetsTUL;
    }

    /// <summary>
    /// Filters variations to only those that target these muscle groups.
    /// </summary>
    public IList<Nutrients> Nutrients { get; } = [];

    /// <summary>
    /// Filters variations to only those that target these muscle groups.
    /// </summary>
    public IDictionary<Nutrients, double>? NutrientTargetsRDA { get; }
    public IDictionary<Nutrients, double>? NutrientTargetsTUL { get; }

    /// <summary>
    /// Makes sure each variations works at least x unique nutrients to be chosen.
    /// If no variations can be found, will drop x by 1 and look again until all nutrients are accounted for.
    /// 
    /// No point in checking non-unique nutrients since small doses of many nutrients are common across recipes.
    /// </summary>
    [Range(UserConsts.AtLeastXNutrientsPerRecipeMin, UserConsts.AtLeastXNutrientsPerRecipeMax)]
    public int? AtLeastXNutrientsPerRecipe
    {
        get => _AtLeastXNutrientsPerRecipe;
        set => _AtLeastXNutrientsPerRecipe = value;
    }
}