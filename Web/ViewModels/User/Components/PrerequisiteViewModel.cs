using Core.Models.Newsletter;
using Lib.ViewModels.Exercise;
using Lib.ViewModels.Newsletter;
using Lib.ViewModels.User;

namespace Web.ViewModels.User.Components;

public class PrerequisiteViewModel
{
    public Verbosity Verbosity => Verbosity.Instructions | Verbosity.Images | Verbosity.ProgressionBar;
    public UserNewsletterViewModel UserNewsletter { get; init; }
    public IList<ExerciseVariationViewModel> VisiblePrerequisites { get; init; }
    public IList<ExerciseVariationViewModel> InvisiblePrerequisites { get; init; }

    public class ExerciseSectionComparer : IEqualityComparer<ExerciseVariationViewModel>
    {
        public bool Equals(ExerciseVariationViewModel? a, ExerciseVariationViewModel? b)
            => EqualityComparer<ExerciseViewModel>.Default.Equals(a?.Exercise, b?.Exercise);

        public int GetHashCode(ExerciseVariationViewModel e) => e.Exercise.GetHashCode();
    }
}
