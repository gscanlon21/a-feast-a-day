using Core.Models.Exercise;
using Core.Models.Newsletter;
using Data.Entities.Exercise;
using Data.Entities.User;
using Data.Models;
using Data.Query;
using System.Diagnostics;

namespace Data.Dtos.Newsletter;

/// <summary>
/// Viewmodel for _Exercise.cshtml
/// </summary>
[DebuggerDisplay("{Section,nq}: {Variation,nq}")]
public class ExerciseVariationDto :
    IExerciseVariationCombo
{
    public ExerciseVariationDto(Section section, Exercise exercise,
        UserExercise? userExercise)
    {
        Section = section;
        Exercise = exercise;
        UserExercise = userExercise;
    }

    public ExerciseVariationDto(QueryResults result)
        : this(result.Section, result.Exercise,
              result.UserExercise)
    { }

    public ExerciseVariationDto(QueryResults result, Intensity intensity, bool needsDeload)
        : this(result.Section, result.Exercise,
              result.UserExercise)
    {
    }

    public Section Section { get; private init; }

    public Exercise Exercise { get; private init; } = null!;


    //[JsonIgnore]
    public UserExercise? UserExercise { get; set; }

    public bool UserFirstTimeViewing { get; private init; } = false;

    public string? EasierVariation { get; init; }
    public string? HarderVariation { get; init; }

    public string? EasierReason { get; init; }
    public string? HarderReason { get; init; }

    public override int GetHashCode() => HashCode.Combine(Exercise);

    public override bool Equals(object? obj) => obj is ExerciseVariationDto other
        && other.Exercise == Exercise;
}
