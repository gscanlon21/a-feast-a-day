using Core.Dtos.User;
using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;

namespace Web.Views.Ingredient;


public class IngredientsViewModel
{
    public IngredientsViewModel() { }

    public IList<IngredientDto> Ingredients { get; set; } = null!;

    public Verbosity Verbosity => Verbosity.Debug;

    [Display(Name = "Ingredient Name")]
    public string? Name { get; init; }

    [Display(Name = "Section")]
    public Section? Section { get; init; }

    public bool FormHasData =>
        !string.IsNullOrWhiteSpace(Name)
        || Section.HasValue;

    internal class IngredientComparer : IEqualityComparer<IngredientDto>
    {
        public bool Equals(IngredientDto? a, IngredientDto? b)
            => EqualityComparer<string>.Default.Equals(a?.Name, b?.Name);

        public int GetHashCode(IngredientDto e) => e.Name.GetHashCode();
    }
}
