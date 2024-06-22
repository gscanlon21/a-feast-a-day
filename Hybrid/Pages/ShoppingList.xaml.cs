using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Dtos.Newsletter;
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
        var checkedList = JsonSerializer.Deserialize<List<int>>(Preferences.Default.Get(nameof(PreferenceKeys.ShoppingList), "[]")) ?? [];

        var shoppingList = await _userService.GetShoppingList(email, token) ?? [];
        foreach (var item in shoppingList)
        {
            item.IsChecked = checkedList.Contains(item.Id) || item.SkipShoppingList;
        }

        Ingredients = new ObservableCollection<RecipeIngredientDto>(shoppingList);
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