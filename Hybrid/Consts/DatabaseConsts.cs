
namespace Hybrid.Consts;

public static class DatabaseConsts
{
    public const string DatabaseFilename = "afeastaday.db3";

    public const SQLite.SQLiteOpenFlags Flags =
        // Open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // Create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // Enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
}