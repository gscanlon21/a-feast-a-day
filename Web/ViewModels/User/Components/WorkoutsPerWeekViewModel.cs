namespace Web.ViewModels.User.Components;

/// <summary>
/// Viewmodel for WorkoutsPerWeek.cshtml
/// </summary>
public class WorkoutsPerWeekViewModel
{
    public Data.Entities.User.User User { get; }

    public int MaxWorkoutsPerWeek { get; }

    public int MinWorkoutsPerWeek { get; }

    public WorkoutsPerWeekViewModel(Data.Entities.User.User user)
    {
        User = user;
    }
}
