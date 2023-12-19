using Core.Models.Newsletter;
using Lib.ViewModels.Exercise;
using Lib.ViewModels.Newsletter;
using Lib.ViewModels.User;

namespace Web.ViewModels.User.Components;

public class PrerequisiteViewModel
{
    public Verbosity Verbosity => Verbosity.Instructions | Verbosity.Images | Verbosity.ProgressionBar;
    public UserNewsletterViewModel UserNewsletter { get; init; }
    public IList<RecipeViewModel> VisiblePrerequisites { get; init; }
    public IList<RecipeViewModel> InvisiblePrerequisites { get; init; }

    public class ExerciseSectionComparer : IEqualityComparer<RecipeViewModel>
    {
        public bool Equals(RecipeViewModel? a, RecipeViewModel? b)
            => EqualityComparer<ExerciseViewModel>.Default.Equals(a?.Exercise, b?.Exercise);

        public int GetHashCode(RecipeViewModel e) => e.Exercise.GetHashCode();
    }
}
