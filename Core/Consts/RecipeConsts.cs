
namespace Core.Consts;

/// <summary>
/// Shared recipe consts.
/// </summary>
public static class RecipeConsts
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

    public const int QuantityNumeratorMin = 1;
    public const int QuantityNumeratorDefault = 1;
    public const int QuantityNumeratorMax = 1000;

    public const int QuantityDenominatorMin = 1;
    public const int QuantityDenominatorDefault = 1;
    public const int QuantityDenominatorMax = 16;
}
