﻿
using Core.Code.Extensions;
using Core.Models.Equipment;
using Core.Models.Exercise;
using Core.Models.Newsletter;
using System.Linq.Expressions;

namespace Data.Query.Options;

public class UserOptions : IOptions
{
    public bool NoUser { get; } = true;
    public int Id { get; }
    public int RefreshExercisesAfterXWeeks { get; }
    public Equipment Equipment { get; }
    public bool IsNewToFitness { get; }
    public DateOnly CreatedDate { get; }

    public bool IgnoreProgressions { get; set; } = false;
    public bool IgnorePrerequisites { get; set; } = false;
    public bool IgnoreIgnored { get; set; } = false;
    public bool IgnoreMissingEquipment { get; set; } = false;

    /// <summary>
    ///     If null, does not exclude any muscle groups from the IncludeMuscle or MuscleGroups set.
    ///     If MuscleGroups.None, does not exclude any muscle groups from the IncludeMuscle or MuscleGroups set.
    ///     If > MuscleGroups.None, excludes these muscle groups from the IncludeMuscle or MuscleGroups set.
    /// </summary>
    public MuscleGroups? ExcludeRecoveryMuscle { get; }

    public UserOptions() { }

    public UserOptions(Entities.User.User user, Section? section)
    {
        NoUser = false;
        Id = user.Id;
        Equipment = user.Equipment;
        IsNewToFitness = user.IsNewToFitness;
        CreatedDate = user.CreatedDate;
        ExcludeRecoveryMuscle = user.RehabFocus.As<MuscleGroups>();

        RefreshExercisesAfterXWeeks = section switch
        {
            Section.Functional => user.RefreshFunctionalEveryXWeeks,
            Section.Accessory => user.RefreshAccessoryEveryXWeeks,
            _ => 0
        };
    }
}
