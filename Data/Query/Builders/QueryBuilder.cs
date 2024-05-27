using Core.Models.Newsletter;
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
    private IngredientGroupOptions? IngredientGroupOptions;
    private ServingsOptions? ServingsOptions;
    private SelectionOptions? SelectionOptions;
    private ExclusionOptions? ExclusionOptions;
    private RecipeOptions? ExerciseOptions;
    private AllergenOptions? AllergenOptions;

    /// <summary>
    /// Looks for similar buckets of exercise variations.
    /// </summary>
    public QueryBuilder()
    {
        Section = Section.None;
    }

    /// <summary>
    /// Looks for similar buckets of exercise variations.
    /// </summary>
    public QueryBuilder(Section section)
    {
        Section = section;
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

    /// <summary>
    /// What progression level should we cap exercise's at?
    /// </summary>
    public QueryBuilder WithServingsOptions(Action<ServingsOptions>? builder = null)
    {
        var options = ServingsOptions ?? new ServingsOptions();
        builder?.Invoke(options);
        ServingsOptions = options;
        return this;
    }

    /// <summary>
    /// Show exercises that work these unique muscle groups.
    /// </summary>
    public QueryBuilder WithIngredientGroups(IMuscleGroupBuilderFinalNoContext builder, Action<IngredientGroupOptions>? optionsBuilder = null)
    {
        var options = builder.Build();
        optionsBuilder?.Invoke(options);
        IngredientGroupOptions = options;
        return this;
    }

    /// <summary>
    /// Filter variations down to the user's progressions.
    /// 
    /// TODO: Refactor user options to better select what is filtered and what isn't.
    /// ..... (prerequisites, progressions, equipment, no use caution when new, unique exercises).
    /// </summary>
    public QueryBuilder WithUser(User user, bool ignoreIgnored = false, bool uniqueExercises = true)
    {
        UserOptions = new UserOptions(user)
        {
            IgnoreIgnored = ignoreIgnored,
        };

        return WithSelectionOptions(options =>
        {
            options.UniqueExercises = uniqueExercises;
        });
    }

    /// <summary>
    /// The exercise ids and not the variation or exercisevariation ids.
    /// </summary>
    public QueryBuilder WithExcludeExercises(Action<ExclusionOptions>? builder = null)
    {
        var options = ExclusionOptions ?? new ExclusionOptions();
        builder?.Invoke(options);
        ExclusionOptions = options;
        return this;
    }

    /// <summary>
    /// The exercise ids and not the variation or exercisevariation ids.
    /// </summary>
    public QueryBuilder WithExercises(Action<RecipeOptions>? builder = null)
    {
        var options = ExerciseOptions ?? new RecipeOptions(Section);
        builder?.Invoke(options);
        ExerciseOptions = options;
        return this;
    }

    /// <summary>
    /// The exercise ids and not the variation or exercisevariation ids.
    /// </summary>
    public QueryBuilder WithAllergens(Action<AllergenOptions>? builder = null)
    {
        var options = AllergenOptions ?? new AllergenOptions();
        builder?.Invoke(options);
        AllergenOptions = options;
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
            IngredientGroupOptions = IngredientGroupOptions ?? new IngredientGroupOptions(),
            ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
            ServingsOptions = ServingsOptions ?? new ServingsOptions(),
            ExerciseOptions = ExerciseOptions ?? new RecipeOptions(),
            SelectionOptions = SelectionOptions ?? new SelectionOptions(),
            AllergenOptions = AllergenOptions ?? new AllergenOptions(),
        };
    }
}