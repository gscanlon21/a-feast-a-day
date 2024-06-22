using Core.Code.Extensions;
using Core.Dtos.Recipe;
using Core.Models.User;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Core.Dtos.User;

/// <summary>
/// Exercises listed on the website
/// </summary>
[Table("recipe_ingredient")]
[DebuggerDisplay("{Name,nq}")]
public class RecipeIngredientDto
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Display(Name = "Ingredient")]
    public int IngredientId { get; init; }

    /// <summary>
    /// Chopped, thinly sliced...
    /// </summary>
    public string? Attributes { get; init; }

    [Range(1, 1000), Display(Name = "Quantity")]
    public int QuantityNumerator { get; set; } = 1;

    [Range(1, 16), Display(Name = "Quantity")]
    public int QuantityDenominator { get; set; } = 1;

    public Fractions.Fraction Quantity => new(QuantityNumerator, QuantityDenominator);

    [Required]
    public Measure Measure { get; set; }

    public bool Optional { get; set; }

    [NotMapped]
    public bool Hide { get; set; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; init; } = null;

    public string? DisabledReason { get; init; } = null;

    [NotMapped]
    public string Name { get => _name ?? Ingredient?.Name ?? ""; init => _name = value; }
    private string? _name;

    [NotMapped]
    public bool SkipShoppingList => Ingredient?.SkipShoppingList ?? false;

    [JsonIgnore]
    public virtual RecipeDto Recipe { get; init; } = null!;

    [JsonInclude]
    public virtual IngredientDto Ingredient { get; set; } = null!;

    public string Title()
    {
        return $"{Name}";
    }

    public string? Desc { get; set; }
    public string Description()
    {
        return Desc ?? $"{QuantityNumerator}/{QuantityDenominator} {Measure.GetSingleDisplayName()}";
    }

    private bool _isChecked;
    public bool IsChecked
    {
        set { SetProperty(ref _isChecked, value); }
        get { return _isChecked; }
    }

    bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
    {
        if (object.Equals(storage, value))
        {
            return false;
        }

        storage = value;
        OnPropertyChanged(propertyName);
        return true;
    }
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    public override int GetHashCode() => HashCode.Combine(Id);

    public override bool Equals(object? obj) => obj is RecipeIngredientDto other
        && other.Id == Id;
}
