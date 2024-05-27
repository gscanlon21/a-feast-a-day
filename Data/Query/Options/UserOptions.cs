namespace Data.Query.Options;

public class UserOptions : IOptions
{
    public bool NoUser { get; } = true;

    public int Id { get; }
    public int? MaxIngredients { get; }
    public bool IsNewToFitness { get; }
    public DateOnly CreatedDate { get; }
    public int RefreshExercisesAfterXWeeks { get; }
    public bool IgnoreIgnored { get; set; } = false;
    public bool IgnoreMissingEquipment { get; set; } = false;

    public UserOptions() { }

    public UserOptions(Entities.User.User user)
    {
        NoUser = false;
        Id = user.Id;
        MaxIngredients = user.MaxIngredients;
        CreatedDate = user.CreatedDate;
    }
}
