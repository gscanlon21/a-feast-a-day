using Core.Dtos.ShoppingList;
using Core.Models.User;
using SQLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Hybrid.Database.Entities;

[DebuggerDisplay("{Id}_{Name,nq}: {IsChecked}")]
public class ShoppingListItem
{
    public ShoppingListItem() { }

    public ShoppingListItem(ShoppingListItemDto dto)
    {
        Name = dto.Name;
        IsCustom = false;
        Measure = dto.Measure;
        Quantity = dto.Quantity;
        Order = dto.Category.GetSingleDisplayName(DisplayType.Order);
        // Don't trigger the property changed event.
        _isChecked = dto.SkipShoppingList;
    }

    [Key, PrimaryKey, AutoIncrement, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public string Name { get; init; } = null!;
    public Measure Measure { get; init; }
    public string? Order { get; init; }
    public int Quantity { get; set; }
    public bool IsCustom { get; init; }

    [NotMapped]
    private bool _isChecked;
    public bool IsChecked
    {
        get { return _isChecked; }
        set { SetProperty(ref _isChecked, value); }
    }

    public string Title()
    {
        return $"{Name}";
    }

    public string Description()
    {
        return Quantity switch
        {
            0 => $"<1 {Measure.GetSingleDisplayName(DisplayType.ShortName)}",
            _ => $"{Quantity} {Measure.GetSingleDisplayName(DisplayType.ShortName)}",
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(storage, value))
        {
            return false;
        }

        storage = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    // Not using Id because we want to compare local with remote.
    public override int GetHashCode() => HashCode.Combine(Name.TrimEnd('s', ' '));
    public override bool Equals(object? obj) => obj is ShoppingListItem other
        && other.Name.TrimEnd('s', ' ') == Name.TrimEnd('s', ' ');
}
