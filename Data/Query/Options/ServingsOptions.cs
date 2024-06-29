using Core.Consts;
using System.ComponentModel.DataAnnotations;

namespace Data.Query.Options;

public class ServingsOptions : IOptions
{
    private int? _atLeastXServingsPerRecipe;

    /// <summary>
    /// Minimum value for AtLeastXUniqueMusclesPerRecipe.
    /// </summary>
    [Range(UserConsts.AtLeastXServingsPerRecipeMin, UserConsts.AtLeastXServingsPerRecipeMax)]
    public int? AtLeastXServingsPerRecipe
    {
        get => _atLeastXServingsPerRecipe;
        set => _atLeastXServingsPerRecipe = value;
    }
}