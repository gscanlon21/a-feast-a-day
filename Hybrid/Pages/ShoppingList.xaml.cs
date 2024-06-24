using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Dtos.User;
using Hybrid.Code;
using Lib.Services;
using System.Text.Json;

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

    public IAsyncRelayCommand LoadCommand { get; set; }

    public ShoppingListPageViewModel(UserService userService)
    {
        _userService = userService;

        LoadCommand = new AsyncRelayCommand(LoadShoppingListAsync);
    }

    [ObservableProperty]
    public string _ingredientEntry = "";

    [ObservableProperty]
    private bool _loading = true;

    [ObservableProperty]
    public ObservableRangeCollection<RecipeIngredientDto> _ingredients = new()
    {
        SortingSelector = a => $"{a.IsChecked}-{a.SkipShoppingList}-{a.Name}"
    };

    [RelayCommand]
    private void WhenCompleted()
    {
        Ingredients.Insert(0, new RecipeIngredientDto()
        {
            Name = IngredientEntry,
        });

        var customList = JsonSerializer.Deserialize<HashSet<string>>(Preferences.Default.Get(nameof(PreferenceKeys.ShoppingListCustom), "[]")) ?? [];
        Preferences.Default.Set(nameof(PreferenceKeys.ShoppingListCustom), JsonSerializer.Serialize(customList.Prepend(IngredientEntry)));
        IngredientEntry = "";
    }

    [RelayCommand]
    private void WhenChecked(RecipeIngredientDto obj)
    {
        if (obj != null)
        {
            var checkedList = JsonSerializer.Deserialize<HashSet<string>>(Preferences.Default.Get(nameof(PreferenceKeys.ShoppingList), "[]")) ?? [];
            if (obj.IsChecked)
            {
                checkedList.Add(obj.Name);
            }
            else
            {
                checkedList.Remove(obj.Name);
            }

            Ingredients.RaiseObjectMoved(obj, Ingredients.IndexOf(obj), Ingredients.IndexOf(obj));
            Preferences.Default.Set(nameof(PreferenceKeys.ShoppingList), JsonSerializer.Serialize(checkedList));
        }
    }

    private async Task LoadShoppingListAsync()
    {
        Loading = true;
        var email = Preferences.Default.Get(nameof(PreferenceKeys.Email), "");
        var token = Preferences.Default.Get(nameof(PreferenceKeys.Token), "");
        var shoppingListHash = Preferences.Default.Get(nameof(PreferenceKeys.ShoppingListHash), 0);

        var shoppingList = (await _userService.GetShoppingList(email, token)).Result;
        if (shoppingList != null)
        {
            // If the week has changed, reset the shopping list.
            if (shoppingListHash != shoppingList!.GetHashCode())
            {
                // Remove unchecked custom items.
                var checkedListRefresh = JsonSerializer.Deserialize<HashSet<string>>(Preferences.Default.Get(nameof(PreferenceKeys.ShoppingList), "[]")) ?? [];
                var customListRefresh = JsonSerializer.Deserialize<HashSet<string>>(Preferences.Default.Get(nameof(PreferenceKeys.ShoppingListCustom), "[]")) ?? [];
                Preferences.Default.Set(nameof(PreferenceKeys.ShoppingListCustom), customListRefresh.Where(cl => !checkedListRefresh.Contains(cl)));

                // Reset checked items to just the common ingredients.
                var defaultCheckedItems = JsonSerializer.Serialize(shoppingList?.ShoppingList.Where(sl => sl.SkipShoppingList).Select(sl => sl.Name));
                Preferences.Default.Set(nameof(PreferenceKeys.ShoppingList), defaultCheckedItems);
                // Update the shopping list hash so we don't reset again until next week.
                Preferences.Default.Set(nameof(PreferenceKeys.ShoppingListHash), shoppingList!.GetHashCode());
            }

            var checkedList = JsonSerializer.Deserialize<HashSet<string>>(Preferences.Default.Get(nameof(PreferenceKeys.ShoppingList), "[]")) ?? [];
            foreach (var item in shoppingList!.ShoppingList ?? [])
            {
                item.IsChecked = checkedList.Contains(item.Name);
            }

            var customList = JsonSerializer.Deserialize<HashSet<string>>(Preferences.Default.Get(nameof(PreferenceKeys.ShoppingListCustom), "[]")) ?? [];
            var customItems = customList.Select(c => new RecipeIngredientDto() { Name = c, IsChecked = checkedList.Contains(c) });
            Ingredients.ReplaceRange(customItems.Concat(shoppingList!.ShoppingList!));
        }

        Loading = false;
        return;
    }

    private class ListComparer : IEqualityComparer<RecipeIngredientDto>
    {
        public bool Equals(RecipeIngredientDto? a, RecipeIngredientDto? b)
            => EqualityComparer<Core.Models.User.Measure?>.Default.Equals(a?.Measure, b?.Measure)
            && EqualityComparer<string?>.Default.Equals(a?.Name.TrimEnd('s', ' '), b?.Name.TrimEnd('s', ' '));

        public int GetHashCode(RecipeIngredientDto e) => HashCode.Combine(e.Measure, e.Name.TrimEnd('s'));
    }
}