using Core.Consts;
using Core.Models;
using Core.Models.Footnote;
using Core.Models.Newsletter;
using Core.Models.User;
using Lib.Pages.Shared.Ingredient;
using Lib.Pages.Shared.Recipe;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lib.Pages.Newsletter;


public class NewsletterViewModel
{
    /// <summary>
    /// The number of footnotes to show in the newsletter
    /// </summary>
    public readonly int FootnoteCount = 2;

    public DateOnly Today { get; init; }

    public UserNewsletterViewModel User { get; init; } = null!;
    public NewsletterEntityViewModel UserWorkout { get; init; } = null!;

    /// <summary>
    /// How much detail to show in the newsletter.
    /// </summary>
    public Verbosity Verbosity { get; init; }

    public List<NewsletterRecipeViewModel> BreakfastRecipes { get; set; } = [];
    public List<NewsletterRecipeViewModel> LunchRecipes { get; set; } = [];
    public List<NewsletterRecipeViewModel> DinnerRecipes { get; set; } = [];
    public List<NewsletterRecipeViewModel> SideRecipes { get; set; } = [];
    public List<NewsletterRecipeViewModel> SnackRecipes { get; set; } = [];
    public List<NewsletterRecipeViewModel> DessertRecipes { get; set; } = [];
    public List<IngredientViewModel> DebugIngredients { get; set; } = [];

    public List<NewsletterRecipeViewModel> AllRecipes => BreakfastRecipes.Concat(LunchRecipes).Concat(DinnerRecipes).Concat(SideRecipes).Concat(DessertRecipes).ToList();


    /// <summary>
    /// Hiding the footer in the demo iframe.
    /// </summary>
    public bool HideFooter { get; set; } = false;

    public Client Client { get; init; }
}

/// <summary>
/// A day's workout routine.
/// </summary>
public class NewsletterEntityViewModel
{
    public int Id { get; init; }

    [Required]
    public int UserId { get; init; }

    /// <summary>
    /// The date the newsletter was sent out on
    /// </summary>
    [Required]
    public DateOnly Date { get; init; }
}



/// <summary>
/// For the newsletter
/// </summary>
public class UserNewsletterViewModel
{
    public int Id { get; init; }

    public string Email { get; init; } = null!;

    public string Token { get; set; } = null!;

    public Features Features { get; init; }

    [Display(Name = "Footnotes")]
    public FootnoteType FootnoteType { get; init; }

    public DateOnly? LastActive { get; init; }

    [Display(Name = "Send Days")]
    public Days SendDays { get; init; }

    [JsonInclude]
    public ICollection<UserRecipeViewModel> UserExercises { get; init; } = null!;

    public int FootnoteCountTop { get; init; }

    public int FootnoteCountBottom { get; init; }

    public bool IsAlmostInactive => LastActive.HasValue && LastActive.Value < DateOnly.FromDateTime(DateTime.UtcNow).AddMonths(-1 * (UserConsts.DisableAfterXMonths - 1));
}
