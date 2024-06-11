﻿using Core.Models.Newsletter;
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
    private ServingsOptions? ServingsOptions;
    private ExclusionOptions? ExclusionOptions;
    private RecipeOptions? ExerciseOptions;
    private EquipmentOptions? EquipmentOptions;
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
    public QueryBuilder WithNutrients(INutrientBuilderFinalNoContext builder, Action<NutrientOptions>? optionsBuilder = null)
    {
        var options = builder.Build();
        optionsBuilder?.Invoke(options);
        NutrientOptions = options;
        return this;
    }

    /// <summary>
    /// Filter variations down to have this equipment.
    /// </summary>
    public QueryBuilder WithEquipment(Equipment equipments, Action<EquipmentOptions>? builder = null)
    {
        var options = EquipmentOptions ?? new EquipmentOptions(equipments);
        builder?.Invoke(options);
        EquipmentOptions = options;
        return this;
    }

    /// <summary>
    /// Filter variations down to the user's progressions.
    /// 
    /// TODO: Refactor user options to better select what is filtered and what isn't.
    /// ..... (prerequisites, progressions, equipment, no use caution when new, unique exercises).
    /// </summary>
    public QueryBuilder WithUser(User user, bool ignoreIgnored = false)
    {
        UserOptions = new UserOptions(user)
        {
            IgnoreIgnored = ignoreIgnored,
        };

        return this;
    }

    /// <summary>
    /// The exercise ids and not the variation or exercisevariation ids.
    /// </summary>
    public QueryBuilder WithExcludeRecipes(Action<ExclusionOptions>? builder = null)
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
            NutrientOptions = NutrientOptions ?? new NutrientOptions(),
            ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
            ServingsOptions = ServingsOptions ?? new ServingsOptions(),
            RecipeOptions = ExerciseOptions ?? new RecipeOptions(),
            AllergenOptions = AllergenOptions ?? new AllergenOptions(),
            EquipmentOptions = EquipmentOptions ?? new EquipmentOptions(),
        };
    }
}