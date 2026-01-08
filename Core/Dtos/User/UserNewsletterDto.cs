using Core.Code.Extensions;
using Core.Code.Helpers;
using Core.Models.Footnote;
using Core.Models.Ingredients;
using Core.Models.Newsletter;
using Core.Models.Recipe;
using Core.Models.User;

namespace Core.Dtos.User;

/// <summary>
/// For the newsletter.
/// </summary>
public class UserNewsletterDto
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public UserNewsletterDto() { }

    public UserNewsletterDto(UserDto user, string token)
    {
        Email = user.Email;
        SendDay = user.SendDay;
        Features = user.Features;
        Verbosity = user.Verbosity;
        Equipment = user.Equipment;
        Allergens = user.Allergens;
        LastActive = user.LastActive;
        CreatedDate = user.CreatedDate;
        FootnoteType = user.FootnoteType;
        MaxIngredients = user.MaxIngredients;
        FontSizeAdjust = user.FontSizeAdjust;
        IngredientOrder = user.IngredientOrder;
        FootnoteCountTop = user.FootnoteCountTop;
        FootnoteCountBottom = user.FootnoteCountBottom;
        Token = token;
    }

    public string Email { get; init; } = null!;

    public string Token { get; set; } = null!;

    public Features Features { get; init; }

    public Allergens Allergens { get; init; }

    public Equipment Equipment { get; init; }

    public FootnoteType FootnoteType { get; init; }

    public DateOnly CreatedDate { get; init; }

    public DateOnly? LastActive { get; init; }

    public Verbosity Verbosity { get; init; }

    public DayOfWeek SendDay { get; init; }

    public int FontSizeAdjust { get; init; }

    public int? MaxIngredients { get; init; }

    public int FootnoteCountTop { get; init; }

    public int FootnoteCountBottom { get; init; }

    public IngredientOrder IngredientOrder { get; set; }

    public IList<Allergens> AllergenList => EnumExtensions.GetSingleValues<Allergens>().Where(a => Allergens.HasFlag(a)).ToList();

    public Allergens AntiAllergens => EnumExtensions.GetSingleValues(excludingAny: Allergens).Aggregate(Allergens.None, (c, n) => c | n);

    public bool IsAlmostInactive => LastActive.HasValue && LastActive.Value < DateHelpers.Today.AddMonths(-1 * (UserConsts.DisableAfterXMonths - 1));

    public bool IsNewlyCreated => CreatedDate >= DateHelpers.Today.AddDays(-7);
}
