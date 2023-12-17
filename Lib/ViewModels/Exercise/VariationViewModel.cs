﻿using Core.Models.Exercise;
using Lib.ViewModels.Equipment;
using Lib.ViewModels.User;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Lib.ViewModels.Exercise;

// TODO: Implement IValidateableObject and setup model validation instead of using the /exercises/check route
/// <summary>
/// Intensity level of an exercise variation
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class VariationViewModel
{
    public int Id { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; init; } = null!;

    /// <summary>
    /// The filename.ext of the static content image
    /// </summary>
    [Required]
    public string StaticImage { get; init; } = null!;

    /// <summary>
    /// The filename.ext of the animated content image
    /// </summary>
    public string? AnimatedImage { get; set; }

    /// <summary>
    /// Does this variation work one side at a time or both sides at once?
    /// </summary>
    [Required]
    public bool Unilateral { get; set; }

    /// <summary>
    /// Is this variation dangerous and needs to be exercised with caution?
    /// </summary>
    [Required]
    public bool UseCaution { get; set; }

    /// <summary>
    /// Can the variation be performed with weights?
    /// 
    /// This controls whether the Pounds selector shows to the user.
    /// </summary>
    [Required]
    public bool IsWeighted { get; set; }

    /// <summary>
    /// Count reps or time?
    /// </summary>
    public bool? PauseReps { get; set; }

    /// <summary>
    /// Where in the newsletter should this exercise be shown.
    /// </summary>
    [Required]
    public ExerciseFocus ExerciseFocus { get; init; }

    /// <summary>
    /// The progression range required to view the exercise variation
    /// </summary>
    [Required]
    public Progression Progression { get; init; } = null!;

    public int ExerciseId { get; init; }

    [JsonInclude]
    public ExerciseViewModel Exercise { get; init; } = null!;

    /// <summary>
    /// Where in the newsletter should this exercise be shown.
    /// </summary>
    [Required]
    public ExerciseType ExerciseType { get; init; }

    public string? DisabledReason { get; init; } = null;

    /// <summary>
    /// Notes about the variation (externally shown)
    /// </summary>
    public string? Notes { get; init; } = null;

    public string? DefaultInstruction { get; init; }

    [JsonInclude]
    public ICollection<InstructionViewModel> Instructions { private get; init; } = new List<InstructionViewModel>();

    public bool HasRootInstructions => Instructions.Any();

    public IOrderedEnumerable<InstructionViewModel> GetRootInstructions(UserNewsletterViewModel? user)
    {
        return Instructions
            // Only show the optional equipment groups that the user owns the equipment of
            .Where(eg => user == null
            // Or the user owns the equipment of the root instruction
            || ((user.Equipment & eg.Equipment) != 0
                // And the root instruction can be done on its own
                // Or the user owns the equipment of the child instructions
                && (eg.Link != null || eg.GetChildInstructions(user).Any())
            ))
            .OrderByDescending(eg => eg.HasChildInstructions)
            // Keep the order consistent across newsletters
            .ThenBy(eg => eg.Id);
    }

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is VariationViewModel other
        && other.Id == Id;
}

/// <summary>
/// The range of progressions an exercise is available for.
/// </summary>
public record Progression([Range(0, 95)] int? Min, [Range(5, 100)] int? Max)
{
    public int MinOrDefault => Min ?? 0;
    public int MaxOrDefault => Max ?? 100;
}
