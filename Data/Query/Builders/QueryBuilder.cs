using Core.Models.Newsletter;
using Core.Models.Recipe;
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
        var options = builder.Build(Section);
        optionsBuilder?.Invoke(options);
        NutrientOptions = options;
        return this;
    }

    /// <summary>
    /// Filter recipes down to have this equipment.
    /// </summary>
    public QueryBuilder WithEquipment(Equipment? equipments, Action<EquipmentOptions>? builder = null)
    {
        var options = EquipmentOptions ?? new EquipmentOptions(equipments);
        builder?.Invoke(options);
        EquipmentOptions = options;
        return this;
    }

    /// <summary>
    /// Filter recipes according to the user's preferences.
    /// </summary>
    /// <param name="ignoreHardFiltering">
    /// Ignores ignored recipes and equipment filtering.
    /// </param>
    public QueryBuilder WithUser(User user, bool ignoreHardFiltering = false)
    {
        UserOptions = new UserOptions(user) { IgnoreIgnored = ignoreHardFiltering };
        return WithEquipment(ignoreHardFiltering ? Equipment.All : user.Equipment);
    }

    public QueryBuilder WithUser(UserOptions userOptions)
    {
        UserOptions = userOptions;
        return this;
    }

    /// <summary>
    /// What progression level should we cap exercise's at?
    /// </summary>
    public QueryBuilder WithSelectionOptions(Action<SelectionOptions>? builder = null)
    {
        var options = SelectionOptions ?? new SelectionOptions();
        builder?.Invoke(options);
        SelectionOptions = options;
        return this;
    }

    public QueryBuilder WithExcludeRecipes(Action<ExclusionOptions>? builder = null)
    {
        var options = ExclusionOptions ?? new ExclusionOptions();
        builder?.Invoke(options);
        ExclusionOptions = options;
        return this;
    }

    public QueryBuilder WithRecipes(Action<RecipeOptions>? builder = null)
    {
        var options = RecipeOptions ?? new RecipeOptions(Section);
        builder?.Invoke(options);
        RecipeOptions = options;
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