using Core.Models.Newsletter;
using Core.Models.Recipe;
using Data.Code.Exceptions;
using Data.Query.Builders.NutrientTargets;
using Data.Query.Options;
using Data.Query.Runners;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public abstract class BaseQueryBuilder<T> where T : BaseQueryBuilder<T>
{
    protected readonly Section Section;

    protected RecipeOptions? RecipeOptions;
    protected ServingOptions? ServingOptions;
    protected DurationOptions? DurationOptions;
    protected NutrientOptions? NutrientOptions;
    protected ExclusionOptions? ExclusionOptions;
    protected EquipmentOptions? EquipmentOptions;
    protected SelectionOptions? SelectionOptions;
    protected IngredientOptions? IngredientOptions;

    /// <summary>
    /// Looks for similar buckets of recipes.
    /// </summary>
    public BaseQueryBuilder(Section section = Section.None)
    {
        Section = section;
    }

    /// <summary>
    /// Show recipes that work these unique nutrient groups.
    /// </summary>
    public virtual T WithIngredients(Action<IngredientOptions>? optionsBuilder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(IngredientOptions);
        IngredientOptions = new IngredientOptions();
        optionsBuilder?.Invoke(IngredientOptions);
        return (T)this;
    }

    /// <summary>
    /// Show recipes that work these unique nutrient groups.
    /// </summary>
    public virtual T WithDuration(Action<DurationOptions>? optionsBuilder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(DurationOptions);
        DurationOptions = new DurationOptions();
        optionsBuilder?.Invoke(DurationOptions);
        return (T)this;
    }

    /// <summary>
    /// Show recipes that work these unique nutrient groups.
    /// </summary>
    public virtual T WithServings(Action<ServingOptions>? optionsBuilder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(ServingOptions);
        ServingOptions = new ServingOptions();
        optionsBuilder?.Invoke(ServingOptions);
        return (T)this;
    }

    /// <summary>
    /// Show recipes that work these unique nutrient groups.
    /// </summary>
    public virtual T WithNutrients(INutrientTargetsBuilder builder, Action<NutrientOptions>? optionsBuilder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(NutrientOptions);
        NutrientOptions = builder.Build(Section);
        optionsBuilder?.Invoke(NutrientOptions);
        return (T)this;
    }

    /// <summary>
    /// Filter recipes down to have this equipment.
    /// </summary>
    public virtual T WithEquipment(Equipment? equipments, Action<EquipmentOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(EquipmentOptions);
        EquipmentOptions ??= new EquipmentOptions(equipments);
        builder?.Invoke(EquipmentOptions);
        return (T)this;
    }

    public virtual T WithExcludeRecipes(Action<ExclusionOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(ExclusionOptions);
        ExclusionOptions ??= new ExclusionOptions();
        builder?.Invoke(ExclusionOptions);
        return (T)this;
    }

    public virtual T WithRecipes(Action<RecipeOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(RecipeOptions);
        RecipeOptions ??= new RecipeOptions(Section);
        builder?.Invoke(RecipeOptions);
        return (T)this;
    }

    /// <summary>
    /// What progression level should we cap exercise's at?
    /// </summary>
    public virtual T WithSelectionOptions(Action<SelectionOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(SelectionOptions);
        SelectionOptions ??= new SelectionOptions();
        builder?.Invoke(SelectionOptions);
        return (T)this;
    }

    /// <summary>
    /// Builds and returns the QueryRunner class with the options selected.
    /// </summary>
    public abstract BaseQueryRunner Build();
}