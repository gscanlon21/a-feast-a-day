using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Hybrid.Database;
using Hybrid.Database.Entities;
using Lib.Services;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using static Hybrid.Database.Entities.ShoppingListItem;

namespace Hybrid;

public partial class ShoppingListPage : ContentPage
{
    private readonly ShoppingListPageViewModel _viewModel;

    /// https://stackoverflow.com/questions/73710578/net-maui-mvvm-navigate-and-pass-object-between-views
    public ShoppingListPage(ShoppingListPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    /// <summary>
    /// Prevents the auto-scroll to keep the moved item visible when an item is checked.
    /// </summary>
    private void Ingredients_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (_viewModel.Loading)
        {
            return;
        }

        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            shoppingListView.ScrollTo(e.NewStartingIndex, position: ScrollToPosition.MakeVisible, animate: false);
        }
        else
        {
            shoppingListView.ScrollTo(e.OldStartingIndex, position: ScrollToPosition.MakeVisible, animate: false);
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _viewModel.Ingredients.CollectionChanged += Ingredients_CollectionChanged;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        _viewModel.Ingredients.CollectionChanged -= Ingredients_CollectionChanged;
    }
}

public partial class ShoppingListPageViewModel : ObservableObject, IDisposable
{
    private readonly UserService _userService;
    private readonly LocalDatabase _localDatabase;
    private readonly UserPreferences _preferences;

    public IAsyncRelayCommand LoadCommand { get; init; }
    public IAsyncRelayCommand WhenCompletedCommand { get; init; }

    public ShoppingListPageViewModel(UserService userService, LocalDatabase localDatabase, UserPreferences preferences)
    {
        _userService = userService;
        _preferences = preferences;
        _localDatabase = localDatabase;

        LoadCommand = new AsyncRelayCommand(LoadShoppingList);
        WhenCompletedCommand = new AsyncRelayCommand(WhenCompleted);
        WeakReferenceMessenger.Default.Register<CheckedMessage>(this, async (_, m) => await WhenChecked(m));
    }

    [ObservableProperty]
    private bool _loading = true;

    [ObservableProperty]
    public string _ingredientEntry = "";

    [ObservableProperty]
    public ObservableCollection<ShoppingListItem> _ingredients = [];

    private async Task WhenCompleted()
    {
        if (!string.IsNullOrWhiteSpace(IngredientEntry) && !await _localDatabase.ContainsItemAsync(IngredientEntry))
        {
            var newIngredient = new ShoppingListItem(IngredientEntry);

            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Ingredients.Insert(OrderIngredients([.. Ingredients, newIngredient]).IndexOf(newIngredient), newIngredient);
            });

            await _localDatabase.SaveItemAsync(newIngredient);
        }

        IngredientEntry = "";
    }

    private async Task WhenChecked(CheckedMessage? message)
    {
        if (message != null && !Loading)
        {
            // Move the item to the end of the list.
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Ingredients.Move(Ingredients.IndexOf(message.Value), OrderIngredients(Ingredients).IndexOf(message.Value));
            });

            await _localDatabase.SaveItemAsync(message.Value);
        }
    }

    private readonly SemaphoreSlim _loadingLock = new(1, 1);
    private async Task LoadShoppingList()
    {
        if (await _loadingLock.WaitAsync(0))
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

                    // Remove all local items that aren't in the remote dataset and aren't custom items.
                    foreach (var localItem in localItems.Except(remoteItems).Where(li => !li.IsCustom))
                    {
                        await _localDatabase.DeleteItemAsync(localItem);
                    }

                    // Add all the remote items that don't exist in the database.
                    foreach (var remoteItem in remoteItems.Except(localItems))
                    {
                        await _localDatabase.SaveItemAsync(remoteItem);                        
                    }

                    // Reset the list.
                    Ingredients.Clear();
                    // Re-pull the list from the db so the Ids are up to date.
                    foreach (var ingredient in OrderIngredients(await _localDatabase.GetItemsAsync()))
                    {
                        // Don't re-init the collection and unbind event handlers.
                        Ingredients.Add(ingredient);
                    }
                }
            }
            finally
            {
                _loadingLock.Release();
                Loading = false;
            }
        }
    }

    private static List<ShoppingListItem> OrderIngredients(IEnumerable<ShoppingListItem> ingredients)
    {
        return ingredients.OrderBy(i => i.IsChecked).ThenBy(i => i.Order).ThenBy(i => i.Group).ThenBy(i => i.Name).ToList();
    }

    public void Dispose()
    {
        WeakReferenceMessenger.Default.UnregisterAll(this);
        GC.SuppressFinalize(this);
    }
}