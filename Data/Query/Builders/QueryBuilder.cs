using Core.Models.Newsletter;
using Core.Models.Recipe;
using Data.Entities.User;
using Data.Query.Options;

namespace Data.Query.Builders;

/// <summary>
/// Builds out the QueryRunner class with option customization.
/// </summary>
public class QueryBuilder
{
    private readonly Section Section;

    private UserOptions? UserOptions;
    private NutrientOptions? NutrientOptions;
    private ExclusionOptions? ExclusionOptions;
    private RecipeOptions? RecipeOptions;
    private EquipmentOptions? EquipmentOptions;

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
    public QueryBuilder WithNutrients(INutrientBuilderFinalNoContext builder, Action<NutrientOptions>? optionsBuilder = null)
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
    /// Filter recipes down to the user's progressions.
    /// 
    /// TODO: Refactor user options to better select what is filtered and what isn't.
    /// ..... (prerequisites, progressions, equipment, no use caution when new, unique recipes).
    /// </summary>
    public QueryBuilder WithUser(User user, bool ignoreAllergens = false, bool ignoreIgnored = false, bool ignoreMissingEquipment = false)
    {
        UserOptions = new UserOptions(user, ignoreAllergens: ignoreAllergens)
        {
            IgnoreIgnored = ignoreIgnored,
        };

        EquipmentOptions = new EquipmentOptions()
        {
            Equipment = !ignoreMissingEquipment ? user.Equipment : null
        };

        return this;
    }

    public QueryBuilder WithUser(UserOptions userOptions, bool? ignoreIgnored = null)
    {
        userOptions.IgnoreIgnored = ignoreIgnored ?? userOptions.IgnoreIgnored;

        UserOptions = userOptions;
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
        };
    }
}