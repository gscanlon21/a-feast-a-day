using Core.Models.Newsletter;
using Lib.ViewModels.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User;

/// <summary>
/// For CRUD actions
/// </summary>
public class UserManageVariationViewModel
{
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public required UserManageExerciseVariationViewModel.Parameters Parameters { get; init; }

    public required Data.Entities.User.User User { get; init; }

    public required IList<ExerciseVariationViewModel> Variations { get; init; } = null!;

    public Verbosity VariationVerbosity => Verbosity.Instructions | Verbosity.Images;

    [Display(Name = "Section")]
    public required Section VariationSection { get; init; }

    [Required, Range(0, 999)]
    [Display(Name = "How much weight are you able to lift?")]
    public int Weight { get; init; }

    internal IList<Xy> Xys { get; init; } = new List<Xy>();

    /// <summary>
    /// For chart.js
    /// </summary>
    internal record Xy(string X, int? Y)
    {
        internal Xy(DateOnly x, int? y) : this(x.ToString("O"), y) { }
    }
}
