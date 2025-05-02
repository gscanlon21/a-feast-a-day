
namespace Core.Consts;

/// <summary>
/// Shared recipe consts.
/// </summary>
public class RecipeConsts
{
    public const int ServingsMin = 1;
    public const int ServingsMax = 12;
    public const int ServingsStep = 1;
    public const int ServingsDefault = 2;

    public const int MaxIngredients = 16;
    public const int MaxInstructions = 8;

    public const double IngredientScaleMin = 0.5;
    public const double IngredientScaleStep = 0.1;
    public const double IngredientScaleDefault = 1.0;
    public const double IngredientScaleMax = 2.0;
}
