using Core.Consts;
using System.ComponentModel.DataAnnotations;

namespace Data.Query.Options;

public class ServingsOptions : IOptions
{
    private int? _atLeastXServingsPerRecipe;
    private int? _weeklyServings;

    [Range(UserConsts.WeeklyServingsMin, UserConsts.WeeklyServingsMax)]
    public int? WeeklyServings
    {
        get => _weeklyServings;
        set => _weeklyServings = value;
    }

    /// <summary>
    /// Minimum value for AtLeastXUniqueMusclesPerRecipe.
    /// </summary>
    [Range(1, 9)]
    public int? AtLeastXServingsPerRecipe
    {
        get => _atLeastXServingsPerRecipe;
        set => _atLeastXServingsPerRecipe = value;
    }
}