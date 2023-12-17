﻿using Core.Models.Equipment;
using Core.Models.Exercise;
using Core.Models.Newsletter;
using Core.Models.User;
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
    private MovementPatternOptions? MovementPatternOptions;
    private SelectionOptions? SelectionOptions;
    private ExclusionOptions? ExclusionOptions;
    private ExerciseOptions? ExerciseOptions;
    private ExerciseTypeOptions? ExerciseTypeOptions;
    private ExerciseFocusOptions? ExerciseFocusOptions;
    private SportsOptions? SportsOptions;
    private JointsOptions? JointsOptions;
    private EquipmentOptions? EquipmentOptions;
    private MuscleContractionsOptions? MuscleContractionsOptions;
    private MuscleMovementOptions? MuscleMovementOptions;

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
    /// Filter exercises down to the specified type.
    /// </summary>
    /// <param name="value">Will filter down to any of the flags values.</param>
    public QueryBuilder WithExerciseFocus(ExerciseFocus value, Action<ExerciseFocusOptions>? builder = null)
    {
        var options = ExerciseFocusOptions ?? new ExerciseFocusOptions(value);
        builder?.Invoke(options);
        ExerciseFocusOptions = options;
        return this;
    }

    /// <summary>
    /// Filter exercises down to the specified type.
    /// </summary>
    public QueryBuilder WithExerciseType(ExerciseType value, Action<ExerciseTypeOptions>? builder = null)
    {
        var options = ExerciseTypeOptions ?? new ExerciseTypeOptions(value);
        builder?.Invoke(options);
        ExerciseTypeOptions = options;
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

    /// <summary>
    /// Filter variations down to these muscle contractions.
    /// </summary>
    public QueryBuilder WithMuscleContractions(MuscleContractions muscleContractions, Action<MuscleContractionsOptions>? builder = null)
    {
        var options = MuscleContractionsOptions ?? new MuscleContractionsOptions(muscleContractions);
        builder?.Invoke(options);
        MuscleContractionsOptions = options;
        return this;
    }

    /// <summary>
    /// Filter variations down to these muscle movement.
    /// </summary>
    public QueryBuilder WithMuscleMovement(MuscleMovement muscleMovement, Action<MuscleMovementOptions>? builder = null)
    {
        var options = MuscleMovementOptions ?? new MuscleMovementOptions(muscleMovement);
        builder?.Invoke(options);
        MuscleMovementOptions = options;
        return this;
    }

    /// <summary>
    /// Filter variations down to these muscle movement.
    /// </summary>
    public QueryBuilder WithMovementPatterns(MovementPattern movementPatterns, Action<MovementPatternOptions>? builder = null)
    {
        var options = MovementPatternOptions ?? new MovementPatternOptions(movementPatterns);
        builder?.Invoke(options);
        MovementPatternOptions = options;
        return this;
    }

    /// <summary>
    /// Filter variations down to the user's progressions.
    /// 
    /// TODO: Refactor user options to better select what is filtered and what isn't.
    /// ..... (prerequisites, progressions, equipment, no use caution when new, unique exercises).
    /// </summary>
    public QueryBuilder WithUser(User user, bool ignoreProgressions = false, bool ignorePrerequisites = false, bool ignoreIgnored = false, bool ignoreMissingEquipment = false, bool uniqueExercises = true)
    {
        UserOptions = new UserOptions(user, Section)
        {
            IgnoreIgnored = ignoreIgnored,
            IgnoreProgressions = ignoreProgressions,
            IgnoreMissingEquipment = ignoreMissingEquipment,
            IgnorePrerequisites = ignorePrerequisites || user.IgnorePrerequisites,
        };

        return WithSelectionOptions(options =>
        {
            options.UniqueExercises = uniqueExercises;
        });
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
    public QueryBuilder WithExercises(Action<ExerciseOptions>? builder = null)
    {
        var options = ExerciseOptions ?? new ExerciseOptions(Section);
        builder?.Invoke(options);
        ExerciseOptions = options;
        return this;
    }

    /// <summary>
    /// Filter variations to the ones that target this sport.
    /// </summary>
    public QueryBuilder WithSportsFocus(SportsFocus sportsFocus, Action<SportsOptions>? builder = null)
    {
        var options = SportsOptions ?? new SportsOptions(sportsFocus);
        builder?.Invoke(options);
        SportsOptions = options;
        return this;
    }

    public QueryBuilder WithJoints(Joints joints, Action<JointsOptions>? builder = null)
    {
        var options = JointsOptions ?? new JointsOptions(joints);
        builder?.Invoke(options);
        JointsOptions = options;
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
            MovementPattern = MovementPatternOptions ?? new MovementPatternOptions(),
            ExclusionOptions = ExclusionOptions ?? new ExclusionOptions(),
            ExerciseOptions = ExerciseOptions ?? new ExerciseOptions(),
            ExerciseTypeOptions = ExerciseTypeOptions ?? new ExerciseTypeOptions(),
            SelectionOptions = SelectionOptions ?? new SelectionOptions(),
            SportsOptions = SportsOptions ?? new SportsOptions(),
            JointsOptions = JointsOptions ?? new JointsOptions(),
            MuscleContractionsOptions = MuscleContractionsOptions ?? new MuscleContractionsOptions(),
            MuscleMovementOptions = MuscleMovementOptions ?? new MuscleMovementOptions(),
            EquipmentOptions = EquipmentOptions ?? new EquipmentOptions(),
            ExerciseFocusOptions = ExerciseFocusOptions ?? new ExerciseFocusOptions(),
        };
    }
}