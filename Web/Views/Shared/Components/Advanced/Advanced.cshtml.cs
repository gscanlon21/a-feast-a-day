using Core.Models.Ingredients;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Shared.Components.Advanced;

public class AdvancedViewModel
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public AdvancedViewModel() { }

    public AdvancedViewModel(Data.Entities.User.User user, string token)
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

    [Display(Name = "Ingredient Order", Description = "What order should ingredients be listed in a recipe?")]
    public IngredientOrder IngredientOrder { get; set; }

    [Display(Name = "Number of Footnotes (Top)")]
    public int FootnoteCountTop { get; set; }

    [Display(Name = "Number of Footnotes (Bottom)")]
    public int FootnoteCountBottom { get; set; }
}
