using Hybrid.Consts;
using Hybrid.Database.Entities;
using SQLite;

namespace Hybrid.Database;

public class LocalDatabase
{
    private SQLiteAsyncConnection Database = null!;

    private async Task Init()
    {
        if (Database is not null)
        {
            return;
        }

        Database = new SQLiteAsyncConnection(DatabaseConsts.DatabasePath, DatabaseConsts.Flags);
        _ = await Database.CreateTableAsync<ShoppingListItem>();
    }

    public async Task<List<ShoppingListItem>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<ShoppingListItem>().ToListAsync();
    }

    public async Task<bool> ContainsItemAsync(string name)
    {
        await Init();
        return (await Database.Table<ShoppingListItem>().CountAsync(i => i.Name == name)) > 0;
    }

    public async Task<ShoppingListItem?> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<ShoppingListItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(ShoppingListItem item)
    {
        await Init();
        if (item.Id != 0)
        {
            return await Database.UpdateAsync(item);
        }
        else
        {
            return await Database.InsertAsync(item);
        }
    }

    public async Task<int> DeleteItemAsync(ShoppingListItem item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }

    /// <summary>
    /// Remove all non-custom items and checked custom items.
    /// </summary>
    /// <returns></returns>
    public async Task<int> DeleteItemsAsync(bool includeCustomChecked = false)
    {
        await Init();

        if (includeCustomChecked)
        {
            return await Database.ExecuteAsync($@"
DELETE FROM [{nameof(ShoppingListItem)}] 
WHERE [{nameof(ShoppingListItem.IsCustom)}] = 0
OR [{nameof(ShoppingListItem.IsChecked)}] = 1");
        }
        else
        {
            return await Database.ExecuteAsync($@"
DELETE FROM [{nameof(ShoppingListItem)}] 
WHERE [{nameof(ShoppingListItem.IsCustom)}] = 0");
        }
    }
}