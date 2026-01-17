using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
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
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public ShoppingListItem() { }

    public ShoppingListItem(string entry)
    {
        Name = entry;
        IsCustom = true;
    }

    public ShoppingListItem(ShoppingListItemDto dto)
    {
        Name = dto.Name;
        Notes = dto.Notes;
        Group = dto.Group;
        Measure = dto.Measure;
        Quantity = dto.Quantity;
        Order = dto.Category.GetOrder();
        // Don't trigger the property changed event.
        _isChecked = dto.SkipShoppingList;
        // This was not made by the user.
        IsCustom = false;
    }

    [Key, PrimaryKey, AutoIncrement, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public string Name { get; init; } = null!;
    public string Group { get; init; } = null!;
    public string? Notes { get; init; }
    public Measure Measure { get; init; }
    public bool IsCustom { get; init; }
    public int? Quantity { get; set; }
    public int? Order { get; init; }

    [NotMapped]
    private bool _isChecked;
    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            if (_isChecked != value)
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
                WeakReferenceMessenger.Default.Send(new CheckedMessage(this));
            }
        }
    }

    public string Title() => $"{QuantityMeasure()} {Name}".Trim();
    public string Description() => Notes?.Trim(',', ' ') ?? "";
    private string QuantityMeasure() => Quantity switch
    {
        0 => $"<1 {Measure.GetSingleDisplayName(DisplayType.ShortName)}".Trim(),
        _ => $"{Quantity} {Measure.GetSingleDisplayName(DisplayType.ShortName)}".Trim(),
    };

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // Not using Id because we want to compare local with remote.
    public override int GetHashCode() => HashCode.Combine(Name.TrimEnd('s', ' '));
    public override bool Equals(object? obj) => obj is ShoppingListItem other
        && other.Name.TrimEnd('s', ' ') == Name.TrimEnd('s', ' ');

    public sealed class CheckedMessage : ValueChangedMessage<ShoppingListItem>
    {
        public CheckedMessage(ShoppingListItem item) : base(item) { }
    }
}
