using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;

namespace Web.Code.Extensions;

public static class TempDataExtensions
{
    /// <summary>
    /// Restore the failed recipe if the upsert model validation failed.
    /// </summary>
    public static T? ReadModel<T>(this ITempDataDictionary tempData, string key) where T : class
    {
        var upsertRecipeString = tempData[key]?.ToString();
        return upsertRecipeString != null ? JsonSerializer.Deserialize<T>(upsertRecipeString) : null;
    }
}
