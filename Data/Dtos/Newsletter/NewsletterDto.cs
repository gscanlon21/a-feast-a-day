using Core.Models.Newsletter;
using Data.Dtos.User;
using Data.Entities.User;

namespace Data.Dtos.Newsletter;

/// <summary>
/// Viewmodel for Newsletter.cshtml
/// </summary>
public class NewsletterDto(UserNewsletterDto user, Entities.Newsletter.UserFeast newsletter)
{
    /// <summary>
    /// The number of footnotes to show in the newsletter
    /// </summary>
    public readonly int FootnoteCount = 2;

    public DateOnly Today { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public UserNewsletterDto User { get; } = user;
    public Entities.Newsletter.UserFeast UserWorkout { get; } = newsletter;

    public List<UserRecipe> BreakfastRecipes { get; set; } = [];
    public List<UserRecipe> LunchRecipes { get; set; } = [];
    public List<UserRecipe> DinnerRecipes { get; set; } = [];
    public List<UserRecipe> SideRecipes { get; set; } = [];
    public List<UserRecipe> DessertRecipes { get; set; } = [];
    public List<UserRecipe> RecipesOfTheDay { get; set; } = [];
    public List<UserRecipe> AllRecipes => BreakfastRecipes.Concat(LunchRecipes).Concat(DinnerRecipes).Concat(SideRecipes).Concat(DessertRecipes).ToList();

    /// <summary>
    /// How much detail to show in the newsletter.
    /// </summary>
    public Verbosity Verbosity { get; } = user.Verbosity;
}
