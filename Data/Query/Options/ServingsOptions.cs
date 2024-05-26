using System.ComponentModel.DataAnnotations;

namespace Data.Query.Options;

public class ServingsOptions : IOptions
{
    private int? _atLeastXServingsPerRecipe;

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