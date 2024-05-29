﻿using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User.Components;

public class AdvancedViewModel
{
    [Obsolete("Public parameterless constructor for model binding.", error: true)]
    public AdvancedViewModel() { }

    public AdvancedViewModel(Data.Entities.User.User user, string token)
    {
        Token = token;
        Email = user.Email;

        FootnoteCountTop = user.FootnoteCountTop;
        FootnoteCountBottom = user.FootnoteCountBottom;
    }

    public bool IsNotDefault => FootnoteCountTop != Data.Entities.User.User.Consts.FootnoteCountTopDefault
        || FootnoteCountBottom != Data.Entities.User.User.Consts.FootnoteCountBottomDefault
        || AtLeastXUniqueNutrientsPerRecipe != 3;

    [Display(Name = "At Least X Unique Nutrients Per Recipe", Description = "A higher value will result in shorter warmup sections and decreased exercise variety.")]
    [Range(1, 9)]
    public int AtLeastXUniqueNutrientsPerRecipe { get; set; }

    [Display(Name = "At Least X Servings Per Recipe", Description = "A higher value will result in shorter warmup sections and decreased exercise variety.")]
    [Range(1, 9)]
    public int AtLeastXServingsPerRecipe { get; set; }

    public string Token { get; init; } = null!;
    public string Email { get; init; } = null!;

    [Display(Name = "Number of Footnotes (Top)")]
    public int FootnoteCountTop { get; set; }

    [Display(Name = "Number of Footnotes (Bottom)")]
    public int FootnoteCountBottom { get; set; }
}
