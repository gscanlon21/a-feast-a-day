using Core.Code.Extensions;
using Core.Models.User;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Lib.ViewModels.Newsletter;

// TODO: Implement IValidateableObject and setup model validation instead of using the /exercises/check route
/// <summary>
/// Intensity level of an exercise variation
/// </summary>
[DebuggerDisplay("{Name,nq}")]
public class RecipeIngredientViewModel : INotifyPropertyChanged
{
    public string Title()
    {
        return $"{Name}";
    }

    public string? Desc { get; set; }
    public string Description()
    {
        return Desc ?? $"{QuantityNumerator}/{QuantityDenominator} {Measure?.GetSingleDisplayName()}";
    }

    public int Id { get; init; }

    /// <summary>
    /// Friendly name.
    /// </summary>
    [Required]
    public string Name { get; init; } = null!;

    public bool SkipShoppingList { get; init; }

    public double CaloriesPerServing { get; set; }

    public double GramsPerServing { get; init; }

    public double GramsPerMeasure { get; init; }
    public Measure DefaultMeasure { get; init; }

    public Allergy Allergens { get; init; }

    public List<NutrientViewModel> Nutrients { get; init; } = [];

    public string? Attributes { get; init; }

    public Fractions.Fraction Quantity => new(QuantityNumerator ?? 0, QuantityDenominator ?? 0);
    public int? QuantityDenominator { get; init; }
    public int? QuantityNumerator { get; init; }

    public Measure? Measure { get; init; }

    /// <summary>
    /// Notes about the variation (externally shown).
    /// </summary>
    public string? Notes { get; init; } = null;

    public string? DisabledReason { get; init; } = null;


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

    public override bool Equals(object? obj) => obj is RecipeInstructionViewModel other
        && other.Id == Id;
}