﻿using Core.Models.Newsletter;
using Lib.Pages.Shared.Ingredient;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Ingredient;


public class IngredientsViewModel
{
    public IngredientsViewModel() { }

    public IList<IngredientViewModel> Ingredients { get; set; } = null!;

    public Verbosity Verbosity => Verbosity.Debug;

    [Display(Name = "Ingredient Name")]
    public string? Name { get; init; }

    [Display(Name = "Section")]
    public Section? Section { get; init; }

    public bool FormHasData =>
        !string.IsNullOrWhiteSpace(Name)
        || Section.HasValue;

    internal class IngredientComparer : IEqualityComparer<IngredientViewModel>
    {
        public bool Equals(IngredientViewModel? a, IngredientViewModel? b)
            => EqualityComparer<string>.Default.Equals(a?.Name, b?.Name);

        public int GetHashCode(IngredientViewModel e) => e.Name.GetHashCode();
    }
}
