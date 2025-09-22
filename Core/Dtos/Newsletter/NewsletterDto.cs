using Core.Dtos.Ingredient;
using Core.Dtos.ShoppingList;
using Core.Dtos.User;
using Core.Models.Newsletter;

namespace Core.Dtos.Newsletter;

public class NewsletterDto
{
    public required UserNewsletterDto User { get; init; }
    public required UserFeastDto UserFeast { get; init; }

    public required ShoppingListDto ShoppingList { get; init; }

    public List<NewsletterRecipeDto> Recipes { get; set; } = [];
    public List<IngredientDto> DebugIngredients { get; set; } = [];

    /// <summary>
    /// How much detail to show in the newsletter.
    /// </summary>
    public required Verbosity Verbosity { get; init; }

    /// <summary>
    /// Hiding the footer in the demo iframe.
    /// </summary>
    public bool HideFooter { get; set; } = false;

    public Client Client { get; set; } = Client.Web;
}
