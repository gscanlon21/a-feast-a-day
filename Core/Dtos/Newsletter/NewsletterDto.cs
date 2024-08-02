using Core.Dtos.Ingredient;
using Core.Dtos.ShoppingList;
using Core.Dtos.User;
using Core.Models.Newsletter;

namespace Core.Dtos.Newsletter;

public class NewsletterDto
{
    /// <summary>
    /// The number of footnotes to show in the newsletter
    /// </summary>
    public readonly int FootnoteCount = 2;

    public DateOnly Today { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public required UserNewsletterDto User { get; init; }
    public required UserFeastDto UserFeast { get; init; }

    public required ShoppingListDto ShoppingList { get; init; }

    public List<NewsletterRecipeDto> BreakfastRecipes { get; set; } = [];
    public List<NewsletterRecipeDto> LunchRecipes { get; set; } = [];
    public List<NewsletterRecipeDto> DinnerRecipes { get; set; } = [];
    public List<NewsletterRecipeDto> SideRecipes { get; set; } = [];
    public List<NewsletterRecipeDto> DessertRecipes { get; set; } = [];
    public List<NewsletterRecipeDto> SnackRecipes { get; set; } = [];
    public List<IngredientDto> DebugIngredients { get; set; } = [];
    public List<NewsletterRecipeDto> AllRecipes => BreakfastRecipes.Concat(LunchRecipes).Concat(DinnerRecipes).Concat(SideRecipes).Concat(DessertRecipes).ToList();

    /// <summary>
    /// How much detail to show in the newsletter.
    /// </summary>
    public required Verbosity Verbosity { get; init; }

    /// <summary>
    /// Hiding the footer in the demo iframe.
    /// </summary>
    public bool HideFooter { get; set; } = false;

    public Client Client { get; set; } = Client.Email;
}
