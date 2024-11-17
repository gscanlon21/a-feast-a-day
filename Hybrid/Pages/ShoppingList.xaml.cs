using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hybrid.Code;
using Hybrid.Database;
using Hybrid.Database.Entities;
using Lib.Services;

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
    private readonly LocalDatabase _localDatabase;
    private readonly UserPreferences _preferences;

    public INavigation Navigation { get; set; } = null!;

    public IAsyncRelayCommand LoadCommand { get; set; }
    public IAsyncRelayCommand WhenCompletedCommand { get; set; }
    public IAsyncRelayCommand WhenCheckedCommand { get; set; }

    public ShoppingListPageViewModel(UserService userService, LocalDatabase localDatabase, UserPreferences preferences)
    {
        _userService = userService;
        _preferences = preferences;
        _localDatabase = localDatabase;

        LoadCommand = new AsyncRelayCommand(LoadShoppingList);
        WhenCompletedCommand = new AsyncRelayCommand(WhenCompleted);
        WhenCheckedCommand = new AsyncRelayCommand<ShoppingListItem>(WhenChecked);
    }

    [ObservableProperty]
    public string _ingredientEntry = "";

    [ObservableProperty]
    private bool _loading = true;

    [ObservableProperty]
    public ObservableRangeCollection<ShoppingListItem> _ingredients = new()
    {
        SortingSelector = a => $"{a.IsChecked}-{a.Order?.Length}-{a.Order}-{a.Name}"
    };

    private async Task WhenCompleted()
    {
        if (!string.IsNullOrWhiteSpace(IngredientEntry)
            && !await _localDatabase.ContainsItemAsync(IngredientEntry))
        {
            var item = new ShoppingListItem()
            {
                Name = IngredientEntry,
                IsCustom = true,
                Quantity = 1,
            };

            Ingredients.Add(item);
            await _localDatabase.SaveItemAsync(item);
        }

        IngredientEntry = "";
    }

    private async Task WhenChecked(ShoppingListItem? obj)
    {
        if (obj != null && !Loading)
        {
            // Move the item to the end of the list.
            Ingredients.RaiseObjectMoved(obj, Ingredients.IndexOf(obj), Ingredients.IndexOf(obj));

            // Save the checked status in the database.
            if (await _localDatabase.GetItemAsync(obj.Id) is ShoppingListItem item)
            {
                item.IsChecked = obj.IsChecked;
                await _localDatabase.SaveItemAsync(item);
            }
        }
    }

    private readonly Lock _loadingLock = new();
    private async Task LoadShoppingList()
    {
        if (_loadingLock.TryEnter())
        {
            try
            {
                var shoppingListHash = Preferences.Default.Get(nameof(PreferenceKeys.ShoppingListHash), 0);
                var shoppingList = (await _userService.GetShoppingList(_preferences.Email.Value, _preferences.Token.Value)).GetValueOrDefault();
                if (shoppingList != null)
                {
                    // If the week has changed, reset the shopping list.
                    if (shoppingListHash != shoppingList!.NewsletterId)
                    {
                        _ = await _localDatabase.DeleteItemsAsync();

                        // Update the shopping list hash so we don't reset again until next week.
                        Preferences.Default.Set(nameof(PreferenceKeys.ShoppingListHash), shoppingList!.NewsletterId);
                    }

                    // Merge local and remote items into the db.
                    var localItems = await _localDatabase.GetItemsAsync();
                    var remoteItems = shoppingList.ShoppingList.Select(sl => new ShoppingListItem(sl)).ToList();
                    foreach (var remoteItem in remoteItems)
                    {
                        if (!localItems.Contains(remoteItem))
                        {
                            await _localDatabase.SaveItemAsync(remoteItem);
                        }
                    }
                    foreach (var localItem in localItems)
                    {
                        if (!localItem.IsCustom && !remoteItems.Contains(localItem))
                        {
                            await _localDatabase.DeleteItemAsync(localItem);
                        }
                    }

                    // Re-pull the list from the db so the Ids are up to date.
                    Ingredients.ReplaceRange(await _localDatabase.GetItemsAsync());
                }
            }
            finally
            {
                _loadingLock.Exit();
                Loading = false;
            }
        }
    }
}