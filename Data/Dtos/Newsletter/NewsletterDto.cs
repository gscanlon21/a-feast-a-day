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

    public List<RecipeDto> BreakfastRecipes { get; set; } = [];
    public List<RecipeDto> LunchRecipes { get; set; } = [];
    public List<RecipeDto> DinnerRecipes { get; set; } = [];
    public List<RecipeDto> SideRecipes { get; set; } = [];
    public List<RecipeDto> DessertRecipes { get; set; } = [];
    public List<RecipeDto> SnackRecipes { get; set; } = [];
    public List<Ingredient> DebugIngredients { get; set; } = [];
    public List<RecipeDto> AllRecipes => BreakfastRecipes.Concat(LunchRecipes).Concat(DinnerRecipes).Concat(SideRecipes).Concat(DessertRecipes).ToList();

    /// <summary>
    /// How much detail to show in the newsletter.
    /// </summary>
    public Verbosity Verbosity { get; } = user.Verbosity;
}
