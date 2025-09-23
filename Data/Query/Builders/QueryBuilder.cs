using Core.Models.Newsletter;
using Core.Models.Recipe;
using Data.Code.Exceptions;
using Data.Entities.User;
using Data.Query.Builders.NutrientTargets;
using Data.Query.Options;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public class QueryBuilder
{
    private readonly Section Section;

    private UserOptions? UserOptions;
    private RecipeOptions? RecipeOptions;
    private NutrientOptions? NutrientOptions;
    private ExclusionOptions? ExclusionOptions;
    private EquipmentOptions? EquipmentOptions;
    private SelectionOptions? SelectionOptions;

    /// <summary>
    /// Looks for similar buckets of recipes.
    /// </summary>
    public QueryBuilder()
    {
        Section = Section.None;
    }

    /// <summary>
    /// Looks for similar buckets of recipes.
    /// </summary>
    public QueryBuilder(Section section)
    {
        Section = section;
    }

    /// <summary>
    /// Show recipes that work these unique nutrient groups.
    /// </summary>
    public QueryBuilder WithNutrients(INutrientTargetsBuilder builder, Action<NutrientOptions>? optionsBuilder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(NutrientOptions);
        NutrientOptions = builder.Build(Section);
        optionsBuilder?.Invoke(NutrientOptions);
        return this;
    }

    /// <summary>
    /// Filter recipes down to have this equipment.
    /// </summary>
    public QueryBuilder WithEquipment(Equipment? equipments, Action<EquipmentOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(EquipmentOptions);
        EquipmentOptions ??= new EquipmentOptions(equipments);
        builder?.Invoke(EquipmentOptions);
        return this;
    }

    /// <summary>
    /// Filter recipes according to the user's preferences.
    /// </summary>
    public QueryBuilder WithUser(User user, Action<UserOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(UserOptions);
        UserOptions ??= new UserOptions(user);
        builder?.Invoke(UserOptions);
        return this;
    }

    public QueryBuilder WithUser(UserOptions userOptions, Action<UserOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(UserOptions);
        UserOptions ??= userOptions;
        builder?.Invoke(UserOptions);
        return this;
    }

    /// <summary>
    /// What progression level should we cap exercise's at?
    /// </summary>
    public QueryBuilder WithSelectionOptions(Action<SelectionOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(SelectionOptions);
        SelectionOptions ??= new SelectionOptions();
        builder?.Invoke(SelectionOptions);
        return this;
    }

    public QueryBuilder WithExcludeRecipes(Action<ExclusionOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(ExclusionOptions);
        ExclusionOptions ??= new ExclusionOptions();
        builder?.Invoke(ExclusionOptions);
        return this;
    }

    public QueryBuilder WithRecipes(Action<RecipeOptions>? builder = null)
    {
        InvalidOptionsException.ThrowIfAlreadySet(RecipeOptions);
        RecipeOptions ??= new RecipeOptions(Section);
        builder?.Invoke(RecipeOptions);
        return this;
    }

    /// <summary>
    /// Builds and returns the QueryRunner class with the options selected.
    /// </summary>
    public QueryRunner Build()
    {
        return new QueryRunner(Section)
        {
            UserOptions = UserOptions ?? new UserOptions(),
            RecipeOptions = RecipeOptions ?? new RecipeOptions(),
            NutrientOptions = NutrientOptions ?? new NutrientOptions(),
            EquipmentOptions = EquipmentOptions ?? new EquipmentOptions(),
            ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
            SelectionOptions = SelectionOptions ?? new SelectionOptions(),
        };
    }
}