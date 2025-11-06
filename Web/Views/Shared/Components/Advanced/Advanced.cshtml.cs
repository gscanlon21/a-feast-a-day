using Core.Models.Ingredients;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.Advanced;

public class AdvancedViewModel
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public AdvancedViewModel() { }

    public AdvancedViewModel(Data.Entities.Users.User user, string token)
    {
        Token = token;
        Email = user.Email;

        IngredientOrder = user.IngredientOrder;
        FootnoteCountTop = user.FootnoteCountTop;
        FootnoteCountBottom = user.FootnoteCountBottom;
    }

    public bool IsNotDefault => IngredientOrder != UserConsts.IngredientOrderDefault
        || FootnoteCountTop != UserConsts.FootnoteCountTopDefault
        || FootnoteCountBottom != UserConsts.FootnoteCountBottomDefault;

    public string Token { get; init; } = null!;
    public string Email { get; init; } = null!;

    [Display(Name = "Ingredient Order", Description = "How should recipe ingredients be ordered?")]
    public IngredientOrder IngredientOrder { get; set; }

    [Display(Name = "Number of User Footnotes", Description = "User footnotes are shown above each feast.")]
    public int FootnoteCountTop { get; set; }

    [Display(Name = "Number of System Footnotes", Description = "System footnotes are shown below each feast.")]
    public int FootnoteCountBottom { get; set; }
}
