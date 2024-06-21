using Core.Dtos.User;
using Core.Models;
using Core.Models.Newsletter;

namespace Core.Dtos.Newsletter;

public class NewsletterDto(UserNewsletterDto user, UserFeastDto newsletter)
{
    /// <summary>
    /// The number of footnotes to show in the newsletter
    /// </summary>
    public readonly int FootnoteCount = 2;

    public DateOnly Today { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public UserNewsletterDto User { get; } = user;
    public UserFeastDto UserFeast { get; } = newsletter;

    public List<RecipeDtoDto> BreakfastRecipes { get; set; } = [];
    public List<RecipeDtoDto> LunchRecipes { get; set; } = [];
    public List<RecipeDtoDto> DinnerRecipes { get; set; } = [];
    public List<RecipeDtoDto> SideRecipes { get; set; } = [];
    public List<RecipeDtoDto> DessertRecipes { get; set; } = [];
    public List<RecipeDtoDto> SnackRecipes { get; set; } = [];
    public List<IngredientDto> DebugIngredients { get; set; } = [];
    public List<RecipeDtoDto> AllRecipes => BreakfastRecipes.Concat(LunchRecipes).Concat(DinnerRecipes).Concat(SideRecipes).Concat(DessertRecipes).ToList();

    /// <summary>
    /// How much detail to show in the newsletter.
    /// </summary>
    public Verbosity Verbosity { get; } = user.Verbosity;

    public Client Client { get; set; } = Client.Email;
}
