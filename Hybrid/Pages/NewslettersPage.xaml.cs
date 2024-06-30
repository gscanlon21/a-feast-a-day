using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Dtos.Newsletter;
using Hybrid.Database;
using Lib.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hybrid;

public partial class NewslettersPage : ContentPage
{
    /// https://stackoverflow.com/questions/73710578/net-maui-mvvm-navigate-and-pass-object-between-views
    public NewslettersPage(NewslettersPageViewModel viewModel)
    {
        InitializeComponent();
        viewModel.Navigation = Navigation;
        BindingContext = viewModel;
    }
}

public partial class NewslettersPageViewModel : ObservableObject
{
    private readonly UserService _userService;
    private readonly UserPreferences _preferences;

    public INavigation Navigation { get; set; } = null!;

    public ICommand NewsletterCommand { get; }

    public IAsyncRelayCommand LoadCommand { get; }

    public NewslettersPageViewModel(UserService userService, UserPreferences preferences)
    {
        _userService = userService;
        _preferences = preferences;

        LoadCommand = new AsyncRelayCommand(LoadRecipesAsync);
        NewsletterCommand = new Command<UserFeastDto>(async (UserFeastDto arg) =>
        {
            await Navigation.PushAsync(new NewsletterPage(arg.Date));
        });
    }

    [ObservableProperty]
    private bool _loading = true;

    [ObservableProperty]
    public ObservableCollection<UserFeastDto>? _recipes = null;

    private async Task LoadRecipesAsync()
    {
        var pastFeasts = await _userService.GetFeasts(_preferences.Email.Value, _preferences.Token.Value);
        Recipes = new ObservableCollection<UserFeastDto>(pastFeasts.Result ?? []);

        Loading = false;
    }
}