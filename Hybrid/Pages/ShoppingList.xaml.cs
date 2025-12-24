using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hybrid.Database;
using Hybrid.Database.Entities;
using Lib.Services;
using System.Collections.ObjectModel;

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

    private void ScrollView_SizeChanged(object sender, EventArgs e)
    {
        if (sender is ScrollView scrollView)
        {
            // Nested scroll to prevent list reordering issues.
            // Set the height to limit nested scrolling issues.
            shoppingListView.HeightRequest = scrollView.Height;
        }
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
    public ObservableCollection<ShoppingListItem> _ingredients = [];

    private async Task WhenCompleted()
    {
        if (!string.IsNullOrWhiteSpace(IngredientEntry)
            && !await _localDatabase.ContainsItemAsync(IngredientEntry))
        {
            var item = new ShoppingListItem()
            {
                Name = IngredientEntry,
                IsCustom = true,
            };

            Ingredients.Insert(0, item);
            await _localDatabase.SaveItemAsync(item);
        }

        IngredientEntry = "";
    }

    private async Task WhenChecked(ShoppingListItem? checkedIngredient)
    {
        if (checkedIngredient != null && !Loading)
        {
            // Move the item to the end of the list.
            Ingredients.Move(Ingredients.IndexOf(checkedIngredient), OrderIngredients(Ingredients).IndexOf(checkedIngredient));

            // Save the checked status in the database.
            if (await _localDatabase.GetItemAsync(checkedIngredient.Id) is ShoppingListItem dbIngredient)
            {
                dbIngredient.IsChecked = checkedIngredient.IsChecked;
                await _localDatabase.SaveItemAsync(dbIngredient);
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
                    // If the newsletter changed, reset the shopping list.
                    if (shoppingListHash != shoppingList.Hash)
                    {
                        // Delete all items except for custom items that haven't been checked.
                        _ = await _localDatabase.DeleteItemsAsync(includeCustomChecked: true);

                        // Update the shopping list hash, so we don't reset again until next week.
                        Preferences.Default.Set(nameof(PreferenceKeys.ShoppingListHash), shoppingList.Hash);
                    }

                    // Merge local and remote items into the db.
                    var localItems = await _localDatabase.GetItemsAsync();
                    var remoteItems = shoppingList.ShoppingList.Select(sl => new ShoppingListItem(sl)).ToList();
                    // Clear the local database of non-custom items for a refresh of remote items.
                    _ = await _localDatabase.DeleteItemsAsync(includeCustomChecked: false);

                    foreach (var remoteItem in remoteItems)
                    {
                        // Keeping the checked status for the remote items.
                        var localItem = localItems.FirstOrDefault(li => li.Equals(remoteItem));
                        remoteItem.IsChecked = localItem?.IsChecked ?? remoteItem.IsChecked;
                        await _localDatabase.SaveItemAsync(remoteItem);
                    }

                    // Reset the list.
                    Ingredients.Clear();
                    // Re-pull the list from the db so the Ids are up to date.
                    Ingredients = new ObservableCollection<ShoppingListItem>(OrderIngredients(await _localDatabase.GetItemsAsync()));
                }
            }
            finally
            {
                _loadingLock.Exit();
                Loading = false;
            }
        }
    }

    private static List<ShoppingListItem> OrderIngredients(IEnumerable<ShoppingListItem> ingredients)
    {
        return ingredients.OrderBy(i => i.IsChecked).ThenBy(i => i.Order?.Length).ThenBy(i => i.Order).ThenBy(i => i.Name).ToList();
    }
}