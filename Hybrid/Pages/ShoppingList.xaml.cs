using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lib.Services;
using Lib.ViewModels.Newsletter;
using System.Collections.ObjectModel;
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

    public IAsyncRelayCommand LoadCommand { get; }

    public ShoppingListPageViewModel(UserService userService)
    {
        _userService = userService;

        LoadCommand = new AsyncRelayCommand(LoadShoppingListAsync);
        UpdateThisItemCommand = new Command<RecipeIngredientViewModel>(CheckboxCommand);
        NewsletterCommand = new Command<UserFeastViewModel>(async (UserFeastViewModel arg) =>
        {
            //await Navigation.PushAsync(new NewsletterPage(arg.Date));
        });
    }

    [ObservableProperty]
    private bool _loading = true;

    [ObservableProperty]
    public ObservableCollection<RecipeIngredientViewModel>? _ingredients = null;

    private void CheckboxCommand(RecipeIngredientViewModel obj)
    {
        if (obj != null)
        {
            obj.IsChecked = !obj.IsChecked;
        }
    }

    private async Task LoadShoppingListAsync()
    {
        var email = Preferences.Default.Get(nameof(PreferenceKeys.Email), "");
        var token = Preferences.Default.Get(nameof(PreferenceKeys.Token), "");
        Ingredients ??= new ObservableCollection<RecipeIngredientViewModel>(
            await _userService.GetShoppingList(email, token) ?? Enumerable.Empty<RecipeIngredientViewModel>()
        );

        Loading = false;
    }
}