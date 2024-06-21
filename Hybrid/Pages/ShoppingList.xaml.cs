using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Code.Extensions;
using Core.Dtos.Feast;
using Core.Dtos.User;
using Lib.Services;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace Hybrid;

public partial class ShoppingListPage : ContentPage
{
    /// https://stackoverflow.com/questions/73710578/net-maui-mvvm-navigate-and-pass-object-between-views
    public ShoppingListPage(ShoppingListPageViewModel viewModel)
    {
        InitializeComponent();
        viewModel.Navigation = Navigation;
        BindingContext = viewModel;
    }
}

public partial class ShoppingListPageViewModel : ObservableObject
{
    private readonly UserService _userService;

    public INavigation Navigation { get; set; } = null!;

    public ICommand NewsletterCommand { get; }
    public ICommand UpdateThisItemCommand { get; set; }
    public ICommand RefreshCommand { get; set; }

    public IAsyncRelayCommand LoadCommand { get; }

    public ShoppingListPageViewModel(UserService userService)
    {
        _userService = userService;

        LoadCommand = new AsyncRelayCommand(LoadShoppingListAsync);
        RefreshCommand = new AsyncRelayCommand(LoadShoppingListAsync);
        UpdateThisItemCommand = new Command<RecipeIngredientDto>(CheckboxCommand);
        NewsletterCommand = new Command<UserFeastViewModel>(async (UserFeastViewModel arg) =>
        {
            //await Navigation.PushAsync(new NewsletterPage(arg.Date));
        });
    }

    [ObservableProperty]
    private bool _loading = true;

    [ObservableProperty]
    public ObservableCollection<RecipeIngredientDto>? _ingredients = null;

    private void CheckboxCommand(RecipeIngredientDto obj)
    {
        if (obj != null)
        {
            var checkedList = JsonSerializer.Deserialize<List<int>>(Preferences.Default.Get(nameof(PreferenceKeys.ShoppingList), "[]")) ?? [];
            if (obj.IsChecked)
            {
                checkedList.Add(obj.Id);
            }
            else
            {
                checkedList.Remove(obj.Id);
            }
            Preferences.Default.Set(nameof(PreferenceKeys.ShoppingList), JsonSerializer.Serialize(checkedList));
        }
    }

    private async Task LoadShoppingListAsync()
    {
        Loading = true;
        var email = Preferences.Default.Get(nameof(PreferenceKeys.Email), "");
        var token = Preferences.Default.Get(nameof(PreferenceKeys.Token), "");
        var shoppingList = await _userService.GetShoppingList(email, token) ?? [];
        var checkedList = JsonSerializer.Deserialize<List<int>>(Preferences.Default.Get(nameof(PreferenceKeys.ShoppingList), "[]")) ?? [];
        foreach (var item in shoppingList)
        {
            item.IsChecked = checkedList.Contains(item.Id) || item.SkipShoppingList;
        }

        var finalShoppingList = new List<RecipeIngredientDto>();
        // There might be a bug where the saved shopping list ids are different than the ones that are choosen for each group.
        foreach (var group in shoppingList.GroupBy(l => l, new ListComparer()).OrderBy(l => l.Key.SkipShoppingList).ThenBy(g => g.Key.Name))
        {
            var wholeFractions = group.Where(g => g.QuantityDenominator == 1).Sum(g => g.QuantityNumerator ?? 0);
            var partialFractions = group.Where(g => g.QuantityDenominator > 1).ToList();
            var fraction = new Fractions.Fraction(wholeFractions + partialFractions.Sum(g => g.QuantityNumerator ?? 0), Math.Max(1, partialFractions.Sum(g => g.QuantityDenominator ?? 0)), true);

            finalShoppingList.Add(new RecipeIngredientDto()
            {
                Id = group.Key.Id,
                Nam = group.Key.Name,
                IsChecked = group.Key.IsChecked,
                Desc = $"{(fraction == Fractions.Fraction.Zero ? "" : $"{fraction} ")}{group.Key.Measure.GetSingleDisplayName()}"
            });
        }

        Ingredients ??= new ObservableCollection<RecipeIngredientDto>(finalShoppingList);
        Loading = false;
    }

    private class ListComparer : IEqualityComparer<RecipeIngredientDto>
    {
        public bool Equals(RecipeIngredientDto? a, RecipeIngredientDto? b)
            => EqualityComparer<Core.Models.User.Measure?>.Default.Equals(a?.Measure, b?.Measure)
            && EqualityComparer<string?>.Default.Equals(a?.Name.TrimEnd('s', ' '), b?.Name.TrimEnd('s', ' '));

        public int GetHashCode(RecipeIngredientDto e) => HashCode.Combine(e.Measure, e.Name.TrimEnd('s'));
    }
}