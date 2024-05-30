using Core.Consts;
using Data.Entities.User;
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
    [Range(User.Consts.AtLeastXServingsPerRecipeMin, User.Consts.AtLeastXServingsPerRecipeMax)]
    public int? AtLeastXServingsPerRecipe
    {
        get => _atLeastXServingsPerRecipe;
        set => _atLeastXServingsPerRecipe = value;
    }
}