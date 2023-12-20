using Core.Models.Newsletter;

namespace Web.ViewModels.User;

/// <summary>
/// For CRUD actions
/// </summary>
public class UserManageExerciseViewModel
{
    public required UserManageExerciseVariationViewModel.Parameters Parameters { get; init; }

    public required Data.Entities.User.User User { get; init; }

    public Verbosity ExerciseVerbosity => Verbosity.Instructions | Verbosity.Images | Verbosity.ProgressionBar;

    /// <summary>
    /// Exercises aren't managed per section, ignoring the section that is only used to manage the variation.
    /// </summary>
    public Section ExerciseSection => Section.None;
}
