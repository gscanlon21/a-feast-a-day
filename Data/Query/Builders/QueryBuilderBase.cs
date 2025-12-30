using Core.Models.Newsletter;
using Core.Models.Recipe;
using Data.Code.Exceptions;
using Data.Query.Builders.NutrientTargets;
using Data.Query.Options;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public abstract class QueryBuilderBase
{
    protected readonly Section Section;

    protected RecipeOptions? RecipeOptions;
    protected NutrientOptions? NutrientOptions;
    protected ExclusionOptions? ExclusionOptions;
    protected EquipmentOptions? EquipmentOptions;
    protected SelectionOptions? SelectionOptions;

    /// <summary>
    /// Looks for similar buckets of recipes.
    /// </summary>
    public QueryBuilderBase()
    {
        Section = Section.None;
    }

    /// <summary>
    /// Looks for similar buckets of recipes.
    /// </summary>
    public QueryBuilderBase(Section section)
    {
        Section = section;
    }

    /// <summary>
    /// Show recipes that work these unique nutrient groups.
    /// </summary>
    public virtual QueryBuilderBase WithNutrients(INutrientTargetsBuilder builder, Action<NutrientOptions>? optionsBuilder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(NutrientOptions);
        NutrientOptions = builder.Build(Section);
        optionsBuilder?.Invoke(NutrientOptions);
        return this;
    }

    /// <summary>
    /// Filter recipes down to have this equipment.
    /// </summary>
    public virtual QueryBuilderBase WithEquipment(Equipment? equipments, Action<EquipmentOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(EquipmentOptions);
        EquipmentOptions ??= new EquipmentOptions(equipments);
        builder?.Invoke(EquipmentOptions);
        return this;
    }

    /// <summary>
    /// What progression level should we cap exercise's at?
    /// </summary>
    public virtual QueryBuilderBase WithSelectionOptions(Action<SelectionOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(SelectionOptions);
        SelectionOptions ??= new SelectionOptions();
        builder?.Invoke(SelectionOptions);
        return this;
    }

    public virtual QueryBuilderBase WithExcludeRecipes(Action<ExclusionOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(ExclusionOptions);
        ExclusionOptions ??= new ExclusionOptions();
        builder?.Invoke(ExclusionOptions);
        return this;
    }

    public virtual QueryBuilderBase WithRecipes(Action<RecipeOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(RecipeOptions);
        RecipeOptions ??= new RecipeOptions(Section);
        builder?.Invoke(RecipeOptions);
        return this;
    }

    /// <summary>
    /// Builds and returns the QueryRunner class with the options selected.
    /// </summary>
    public abstract QueryRunner Build();
}